    public Point RotatePoint(float angle, Point pt) { 
       var a = a * System.Math.PI / 180.0;
       float cosa = Math.Cos(a), sina = Math.Sin(a);
       return new Point(pt.X * cosa - pt.Y * sina, pt.X * sina + pt.Y * cosa);
    }
