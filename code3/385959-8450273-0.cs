    public class MyLine
    {
        public Pen pen { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
    
        public MyLine(Pen p, Point p1, Point p2)
        {
            pen = p;
            Start = p1;
            End = p2;
        }
    
        public float slope
        {
            get
            {
                return (((float)End.Y - (float)Start.Y) / ((float)End.X - (float)Start.X));
            }
        }
        public float YIntercept
        {
            get
            {
                return Start.Y - slope*Start.X;
            }
        }
    
        public bool IsPointOnLine(Point p, int cushion)
        {
            float temp = (slope * p.X + YIntercept);
            if (temp >= (p.Y-cushion) && temp <=(p.Y+cushion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
