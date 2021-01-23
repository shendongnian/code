    Point mousePos = new Point();
    List<Point> points = new List<Point>();
        
    var closest = (from Point p in points 
                  select new { 
                    Vector = (mousePos - p), 
                    Point = p }
                  ).OrderBy(a => a.Vector.Length).FirstOrDefault();
    
    if (closest != null)
    {
        double distance = closest.Vector.Length;
        Point closesPoint = closest.Point;
    }
