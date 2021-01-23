    List<Point> points = new List<Point>();
    //Fill you list of points here with points.Add(new Point(2,2)); etc.
    Point p = new Point(2,2);
    if (points.Contains(p))
    {
          points.Remove(p);
    }
    //This will give you a new list where predicate condition is met, where Point X not equal to 2 and point Y is not equal to 2
    var newList = points.Where(p => p.X != 2 & p.Y != 2);
    //Note if you use the above you do not need to remove the point(2,2) from the Points List
