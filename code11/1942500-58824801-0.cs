    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(ClientSize.Width/2, ClientSize.Height/2);
            PointF A = new PointF(0, -40);
            PointF B = new PointF(100, 40);
            e.Graphics.DrawLine(Pens.DarkBlue, A, B);
            DrawPoint(e.Graphics, Brushes.Black, A);
            DrawPoint(e.Graphics, Brushes.Black, B);
            DrawArcBetweenTwoPoints(e.Graphics, Pens.Red, A, B, 100);
            
        }
        public void DrawPoint(Graphics g, Brush brush, PointF A, float size = 8f)
        {
            g.FillEllipse(brush, A.X-size/2, A.Y-size/2, size, size);
        }
        public void DrawArcBetweenTwoPoints(Graphics g, Pen pen,  PointF a, PointF b, float radius, bool flip = false)
        {
            if (flip)
            {
                PointF temp = b;
                b =a;
                a = temp;
            }
            // get distance components
            double x = b.X-a.X, y = b.Y-a.Y;
            // get orientation angle
            var θ = Math.Atan2(y, x);
            // length between A and B
            var l = Math.Sqrt(x*x+y*y);
            if (2*radius>=l)
            {
                // find the sweep angle (actually half the sweep angle)
                var φ = Math.Asin(l/(2*radius));
                // triangle height from the chord to the center
                var h = radius*Math.Cos(φ);
                // get center point. 
                // Use sin(θ)=y/l and cos(θ)=x/l
                PointF C = new PointF(
                    (float)(a.X + x/2 - h*(y/l)),
                    (float)(a.Y + y/2 + h*(x/l)));
                g.DrawLine(Pens.DarkGray, C, a);
                g.DrawLine(Pens.DarkGray, C, b);
                DrawPoint(g, Brushes.Orange, C);
                // Draw arc based on square around center and start/sweep angles
                g.DrawArc(pen, C.X-radius, C.Y-radius, 2*radius, 2*radius,
                    (float)((θ-φ)*to_deg)-90, (float)(2*φ*to_deg));
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
