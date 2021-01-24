    public class DrawAction
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public Color c1 { get; set; }
        public int mode { get; set; }
        public DrawAction(Point p1_, Point p2_, Color c_, int mode_)
        {
            p1 = p1_; p2 = p2_; c1 = c_; mode = mode_;
        }
        public void Draw(Graphics g)
        {
            switch (mode)
            {
                case 0: // line
                    using (Pen pen = new Pen(c1)) 
                      g.DrawLine(pen, p1, p2);
                    break;
                case 1: // rectangle
                    using (Pen pen = new Pen(c1)) 
                      g.DrawRectangle(pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                    break;
                case 2: // filled rectangle
                    using (SolidBrush brush = new SolidBrush(c1)) 
                      g.FillRectangle(brush, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                    break;
                default:
                    break;
            }
        }
    }
