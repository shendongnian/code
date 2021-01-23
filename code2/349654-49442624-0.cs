    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace BorderExp
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MaxClick(object sender, EventArgs e)
        {
            if (WindowState ==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void MinClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
           }
        }
        }
