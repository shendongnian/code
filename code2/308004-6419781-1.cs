    public partial class Form1 : Form
    {
        private readonly List<Rectangle> rects = new List<Rectangle>();
        private Point tempStartPoint;
        private Rectangle tempRect;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            tempStartPoint = e.Location;
            Invalidate();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            tempRect =
                new Rectangle(
                    Math.Min(tempStartPoint.X, tempEndPoint.X),
                    Math.Min(tempStartPoint.Y, tempEndPoint.Y),
                    Math.Abs(tempStartPoint.X - tempEndPoint.X),
                    Math.Abs(tempStartPoint.Y - tempEndPoint.Y));
            Invalidate();
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Must be within constraint, prevents tiny invisible rectangles from being added
            if (tempRect.Width >= 10 && tempRect.Height >= 10)
                rects.Add(tempRect);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                // Redraws all existing rectangles onto the form
                foreach (Rectangle rect in rects)
                    e.Graphics.DrawRectangle(pen, rect);
                // Must be within constraint, prevents tiny invisible rectangles from being added
                if (tempRect.Width >= 10 && tempRect.Height >= 10)
                    e.Graphics.DrawRectangle(pen, tempRect);
            }
        }
    }
