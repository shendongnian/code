    namespace Drawing
    {
        public partial class Form1 : Form
        {
            bool draw = false;
    
            int pX = -1;
            int pY = -1;
    
            Bitmap drawing;
    
            public Form1()
            {
                InitializeComponent();
    
                drawing = new Bitmap(panel1.Width, panel1.Height, panel1.CreateGraphics());
                Graphics.FromImage(drawing).Clear(Color.White);
            }
    
            private void panel1_MouseMove(object sender, MouseEventArgs e)
            {
                if (draw)
                {
                    Graphics panel = Graphics.FromImage(drawing);
    
                    Pen pen = new Pen(Color.Black, 14);
    
                    pen.EndCap = LineCap.Round;
                    pen.StartCap = LineCap.Round;
    
                    panel.DrawLine(pen, pX, pY, e.X, e.Y);
    
                    panel1.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
                }
    
                pX = e.X;
                pY = e.Y;
            }
    
            private void panel1_MouseDown(object sender, MouseEventArgs e)
            {
                draw = true;
    
                pX = e.X;
                pY = e.Y;
            }
    
            private void panel1_MouseUp(object sender, MouseEventArgs e)
            {
                draw = false;
            }
    
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawImageUnscaled(drawing, new Point(0, 0));
            }
        }
    }
