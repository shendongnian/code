    public partial class ScreenSelection : Form
    {
        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        private List<Rectangle> Rects = new List<Rectangle>();
        private bool RectStart = false;
        public ScreenSelection(DataTable buttonData)
        {
            InitializeComponent();
        }
       private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (RectStartPoint == e.Location)
                {
                    int i = Rects.Count;
                    if (i > 0) { Rects.RemoveAt(i - 1); }
                    Canvas.Refresh();
                }
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RectStartPoint = e.Location;
                int i = Rects.Count;
                if (i >= 1) { Rects.RemoveAt(i - 1); }
                RectStart = false;
                Canvas.Refresh();
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            if (!RectStart)
            {
                Rects.Add(Rect);
                RectStart = true;
            }
            else
            {
                Rects[(Rects.Count - 1)] = Rect;
            }
            Canvas.Invalidate(); 
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (Canvas.Image != null)
            {
                if (Rects.Count > 0)
                {
                    e.Graphics.FillRectangles(selectionBrush, Rects.ToArray());
                }
            }
            
        }
    }
