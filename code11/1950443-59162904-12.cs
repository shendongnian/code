    public class Ellipse
    {
        public Rectangle Rectangle { get; set; }
        public float Angle { get; set; }
        public PointF Center => new PointF(
            Rectangle.Left + 0.5f * Rectangle.Width,
            Rectangle.Top + 0.5f * Rectangle.Height);
    }
