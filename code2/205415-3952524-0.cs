    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace winap
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private bool DrawText = false;
            
            private void button1_Click(object sender, EventArgs e)
            {
                DrawText = !DrawText;
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                
                if(DrawText)
                {
                    if (lp != p)
                    {
                        this.Invalidate();
                    }
                
                    e.Graphics.DrawString("hi", SystemFonts.DefaultFont, Brushes.Green, p);
                    lp = p; 
                }
                
            }
    
            private PointF p;
            private PointF lp;
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                p = new PointF(e.X -10, e.Y);
                this.Invalidate();
            }
        }
    }
