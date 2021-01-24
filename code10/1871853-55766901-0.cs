    public partial class Dot : UserControl
    {
        private bool _Checked = false;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                this.Invalidate();
            }
        }
        public Dot()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SizeChanged += Dot_SizeChanged;
        }
        private void Dot_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);            
            int radius = (int)(Math.Min(this.ClientRectangle.Width, this.ClientRectangle.Height) / 2);
            if (radius > 0)
            {
                double outerCircle = 0.95;
                double innerCircle = 0.80;
                Rectangle rc = new Rectangle(new Point(0, 0), new Size(1, 1));
                rc.Inflate((int)(radius * outerCircle), (int)(radius * outerCircle));
                Point center = new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2);
                e.Graphics.TranslateTransform(center.X, center.Y);
                e.Graphics.DrawEllipse(Pens.Black, rc);
                if (this.Checked)
                {
                    rc = new Rectangle(new Point(0, 0), new Size(1, 1));
                    rc.Inflate((int)(radius * innerCircle), (int)(radius * innerCircle));
                    e.Graphics.FillEllipse(Brushes.Black, rc);
                }
            }            
        }
    }
