    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication10
    {
        public partial class Form1 : Form
        {
            Bitmap bitmap = null;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Redraw();
            }
    
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                OnPaint(e);
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                if (bitmap == null)
                {
                    base.OnPaint(e);
                }
                else
                {
                    e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
                }
            }
    
            private void Form1_Resize(object sender, EventArgs e)
            {
                Redraw();
            }
    
            private void Form1_ResizeEnd(object sender, EventArgs e)
            {
                Redraw();
                this.Invalidate();
            }
    
            private void Redraw()
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                    bitmap = null;
                }
                bitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.White);
                    // This is where you could use a List<Shape> etc...
                    g.DrawEllipse(Pens.Black, new Rectangle(10, 10, 20, 20));
                    g.DrawEllipse(Pens.Black, new Rectangle(20, 30, 20, 20));
                    g.DrawEllipse(Pens.Black, new Rectangle(50, 90, 30, 20));
                }
            }
    
    
    
        }
    }
