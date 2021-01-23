    public struct Line
    {
        public int XMin { get { ... } }
        public int XMax { get { ... } }
        
        public int YMin { get { ... } }
        public int YMax { get { ... } }
        
        public Line(Point a, Point b) { ... }
        
        public float CalculateYForX(int x) { ... }
    }
    public bool Intersects(Point a, Point b, Rectangle r)
    {
        var line = new Line(a, b);
        
        if (r.Left > line.XMax || r.Right < line.XMin)
        {
            return false;
        }
        
        if (r.Top < line.YMin || r.Bottom > line.YMax)
        {
            return false;
        }
        
        var yAtRectLeft = line.CalculateYForX(r.Left);
        var yAtRectRight = line.CalculateYForX(r.Right);
        
        if (r.Bottom > yAtRectLeft && r.Bottom > yAtRectRight)
        {
            return false;
        }
        
        if (r.Top < yAtRectLeft && r.Top < yAtRectRight)
        {
            return false;
        }
        
        return true;
    }
