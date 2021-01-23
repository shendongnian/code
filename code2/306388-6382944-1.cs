    public partial class DrawingCanvas : PictureBox
    {
        public DrawingCanvas()
        {
            InitializeComponent();
            SetStyle(
                  ControlStyles.AllPaintingInWmPaint | 
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.ResizeRedraw, true);
        }
        
        private Point start = new Point(0, 0);
        private Point end = new Point(0, 0);
        protected override void OnMouseDown(MouseEventArgs e)
        {
            start = e.Location;
            end = e.Location;
            Invalidate();
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // This makes sure that the left mouse button is pressed.
            if (e.Button == MouseButtons.Left)
                end = e.Location;
            
            Invalidate();
            base.OnMouseMove(e);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            int top = start.Y < end.Y ? start.Y : end.Y;
            int left = start.X < end.X ? start.X : end.X;
            int width = end.X - start.X; if (width < 0) width = -width;
            int height = end.Y - start.Y; if (height < 0) height = -height;
            Rectangle rect = new Rectangle(left, top, width, height);
            
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
