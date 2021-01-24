using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace ControlloMotori_v01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PorteDisponibili();
        }
        //Definisco una funzione che ricerca le porte disponibili
        void PorteDisponibili()
        {
            string[] porte = SerialPort.GetPortNames();
            CmBox_PortaSeriale.Items.AddRange(porte);
        }
        private void btn_Connetti_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmBox_BaudRate.Text == "" || CmBox_PortaSeriale.Text == "")
                {
                    MessageBox.Show("Selezionare impostazioni per la porta seriale");
                }
                else
                {
                    SerialPort01.PortName = CmBox_PortaSeriale.Text;
                    SerialPort01.BaudRate = Convert.ToInt32(CmBox_BaudRate.Text);
                    SerialPort01.Open();
                    GroupBox1.Enabled = true;
                    btn_Disconnetti.Enabled = true;
                    btn_Connetti.Enabled = false;
                    CmBox_BaudRate.Enabled = false;
                    CmBox_PortaSeriale.Enabled = false;
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Unauthorized Access Exception");
            }
        }
        private void btn_Disconnetti_Click(object sender, EventArgs e)
        {
            SerialPort01.Close();
            GroupBox1.Enabled = false;
            btn_Disconnetti.Enabled = false;
            btn_Connetti.Enabled = true;
            CmBox_PortaSeriale.Enabled = true;
            CmBox_BaudRate.Enabled = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                SerialPort01.Write("L");
            }
            if (keyData == Keys.Right)
            {
                SerialPort01.Write("R");
            }
            if (keyData == Keys.Up)
            {
                SerialPort01.Write("U");
            }
            if (keyData == Keys.Down)
            {
                SerialPort01.Write("D");
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
