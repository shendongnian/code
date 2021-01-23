    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
        class test : Form
        {
            public test() : base()
            {
                this.TopMost = true;
                this.DoubleBuffered = true;
                this.ShowInTaskbar = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.BackColor = Color.Purple;
                this.TransparencyKey = Color.Purple;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(Pens.Black, 0, 0, 200, 200);
            }
            public static void Main(String[] args)
            {
                Application.Run(new test());
            }
        }
    }
