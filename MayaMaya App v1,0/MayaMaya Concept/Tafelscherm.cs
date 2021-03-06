﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayaMaya_Concept
{
    public partial class Tafelscherm : Form
    {
        Tafel tafel;
        TafelDAO tafelDAO;

        public Tafelscherm(Tafel tafel, TafelDAO tafeldao)
        {
            InitializeComponent();
            this.tafel = tafel;
            this.tafelDAO = tafeldao;
        }

        private void btnBevestig_Click(object sender, EventArgs e)
        {

        }

        private void Tafelklikscherm_Load(object sender, EventArgs e)
        {
            btnTafel.Text = String.Format("Tafel {0}", tafel.tafelNummer);
            GetStatus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void btnTerug_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTafel_Click(object sender, EventArgs e)
        {
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            tafelDAO.UpdateTafel(tafel);
            GetStatus();
        }

        public void GetStatus()
        {
            if(tafelDAO.GetStatus(tafel))
            {
                btnStatus.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                btnStatus.BackColor = System.Drawing.Color.Green;
            }
        }

        private void btnOpnemen_Click(object sender, EventArgs e)
        {
            Bestelling1 bestellingscherm = new Bestelling1(tafel);
            this.Hide();
            bestellingscherm.ShowDialog();
            this.Show();
        }

        private void btnAfrekenen_Click(object sender, EventArgs e)
        {
            AfrekenBetaalscherm BetaalScherm = new AfrekenBetaalscherm();
            this.Hide();
            BetaalScherm.ShowDialog();
            this.Show();
        }
    }
}
