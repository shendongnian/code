    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Flickering
    {
        public partial class Form1 : Form
        {
            Timer timer;
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            Size speed = new Size(3, 1);
            Size step = new Size(3, 1);
    
            public Form1()
            {
                InitializeComponent();
    
                this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
    
                timer = new Timer();
                timer.Interval = 20;
                timer.Tick += new EventHandler(Tick);
                timer.Enabled = true;
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                //e.Graphics.FillRectangle(Brushes.DarkCyan, ClientRectangle);
                e.Graphics.FillRectangle(Brushes.White, rect);
            }
    
            public void Tick(object source, EventArgs e)
            {
                var canvas = ClientRectangle;
                step.Width = rect.Right >= canvas.Width ? -speed.Width : rect.Left < canvas.Left ? speed.Width : step.Width;
                step.Height = rect.Bottom >= canvas.Height ? -speed.Height : rect.Top < canvas.Top ? speed.Height : step.Height;
                rect.Location += step;
    
                Invalidate();
            }
        }
    }
