    public partial class Form1 : Form
    {
        private int radius = 6;
        private int jiggleDistance = 3;      
        private int numberOfDots = 100;
        private Random R = new Random();
        private int lineDistanceThreshold = 50;
        private List<Point> dots = new List<Point>();
        private System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            populateDots();
            tmr.Tick += Tmr_Tick;
            tmr.Interval = 100;
            tmr.Start();
        }
        private void populateDots()
        {
            dots.Clear();
            for (int i = 1; i <= numberOfDots; i++)
            {
                Point dot = new Point(
                    R.Next(radius, this.ClientRectangle.Width - radius),
                    R.Next(radius, this.ClientRectangle.Height - radius));
                dots.Add(dot);
            }
        }
        private void Tmr_Tick(object sender, EventArgs e)
        {
            for(int i=0; i < dots.Count; i++)
            {
                Point dot = dots[i];
                dot.Offset(R.Next(-1, 2) * jiggleDistance, R.Next(-1, 2) * jiggleDistance);
                if (dot.X < radius)
                {
                    dot = new Point(radius, dot.Y);
                }
                if (dot.X > this.ClientRectangle.Width - radius)
                {
                    dot = new Point(this.ClientRectangle.Width - radius, dot.Y);
                }
                if (dot.Y < radius)
                {
                    dot = new Point(dot.X, radius);
                }
                if (dot.Y > this.ClientRectangle.Height - radius)
                {
                    dot = new Point(dot.X, this.ClientRectangle.Height - radius);
                }
                dots[i] = dot;
            }
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // connecting lines: *very ineffecient, draws lines twice
            foreach(Point dot in dots)
            {
                foreach(Point otherDot in dots)
                {
                    if (otherDot != dot)
                    {
                        if(dotToDotDistance(dot, otherDot) <= lineDistanceThreshold)
                        {
                            e.Graphics.DrawLine(Pens.Blue, dot, otherDot);
                        }
                    }
                }
            }
            // dots on top of lines:
            foreach (Point dot in dots)
            {
                Rectangle rc = new Rectangle(dot, new Size(1, 1));
                rc.Inflate(radius, radius);
                e.Graphics.FillEllipse(Brushes.Black, rc);
            }
        }
        private double dotToDotDistance(Point ptA, Point ptB)
        {
            return Math.Sqrt(Math.Pow(ptB.X - ptA.X, 2) + Math.Pow(ptB.Y - ptA.Y, 2));
        }
        
    }
