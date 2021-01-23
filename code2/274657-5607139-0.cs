      public class Line
    {
        public float X1 { get; set; }
        public float X2 { get; set; }
        public float Y1 { get; set; }
        public float Y2 { get; set; }
    }
    public sealed class Grid : Panel
    {
        readonly DotDrawing drawing = new DotDrawing();
        private List<Line> Markers { get; set; }
        public Grid()
        {
            this.DoubleBuffered = true;
            Markers = new List<Line>();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            
            foreach (Line line in Markers)
            {
                using (Pen pen = new Pen(Brushes.Black))
                {
                    pen.Width = 2;
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    e.Graphics.DrawLine(pen, line.X1, line.Y1, line.X2, line.Y2);
                }
            }drawing.Render(e.Graphics);
            base.OnPaint(e);
        }
        private Dot lastDot;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            var x = this.drawing.GetDotFromPoint(e.Location);
            if (x != null)
            {
                lastDot = x;
            }
            else
            {
                lastDot = null;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            var x = this.drawing.GetDotFromPoint(e.Location);
            if (x != null)
            {
                Line line = new Line();
                line.X1 = lastDot.Center.X;
                line.Y1 = lastDot.Center.Y;
                line.X2 = x.Center.X;
                line.Y2 = x.Center.Y;
                this.Markers.Add(line);
                Invalidate();
            }
        }
    }
    public class Dot
    {
        public PointF Location { get; set; }
        public int Radius { get; set; }
        public PointF Center
        {
            get
            {
                return new PointF(this.Bounds.Left + (float)this.Radius,
                    this.Bounds.Top + (float)this.Radius);
            }
        }
        public RectangleF Bounds
        {
            get
            {
                return new RectangleF(Location, new SizeF(2 * Radius, 2 * Radius));
            }
        }
        public Dot()
        {
            Radius = 5;
        }
    }
    public class DotDrawing
    {
        private List<Dot> Dots { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public int ColumnSpacing { get; set; }
        public int RowSpacing { get; set; }
        public int DotRadius { get; set; }
        public DotDrawing()
        {
            Dots = new List<Dot>();
            DotRadius = 10;
            ColumnCount = 15;
            RowCount = 25;
            this.RowSpacing = 30;
            this.ColumnSpacing = 30;
        }
        public void Render(Graphics g)
        {
            this.Dots.Clear();
            float x = 0;
            float y = 0;
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    {
                        Dot dot = new Dot();
                        dot.Location = new PointF(x, y);
                        using (SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#009aff")))
                        {
                            g.FillEllipse(brush, dot.Location.X, dot.Location.Y, DotRadius, DotRadius);
                            
                        }
                        x += (DotRadius + ColumnSpacing);
                        Dots.Add(dot);
                    }
                }
                x = 0;
                y += (DotRadius + this.RowSpacing);
            }
        }
        public Dot GetDotFromPoint(PointF point)
        {
            for (int i = 0; i < this.Dots.Count; i++)
            {
                RectangleF rect = this.Dots[i].Bounds;
                rect.Inflate(new SizeF(3, 3));
                Region region = new Region(rect);
                if (region.IsVisible(point))
                {
                    return this.Dots[i];
                }
            }
            return null;
        }
    }
