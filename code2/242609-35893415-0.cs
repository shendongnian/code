    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        Form2 F2;
        public Form1()
        {
            InitializeComponent();
            F2 = new Form2();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Panel P1 = new Panel();
            P1.Location = new Point(0, 0);
            P1.Height = this.Height;
            P1.Width = this.Width;
            P1.BackColor = Color.Transparent;
            this.Controls.Add(P1);
            SetParent(F2.Handle, P1.Handle);
            F2.Owner = this;
            F2.Show();
        }
    }
