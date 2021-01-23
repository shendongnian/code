    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
    //         Graphics g;
            public Form1()
            {
                InitializeComponent();
    //            g = CreateGraphics();
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Pen pen = new Pen(Color.Black);
                for (int i = 0; i < this.ClientSize.Height; i++)
                {
       //             g.DrawLine(pen, 100, i, 50, i);
                    e.Graphics.DrawLine(pen, 100, i, 50, i);
                }
            }
        }
    }
