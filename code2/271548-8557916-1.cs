      public static double Length(Point a, Point b)
      {
         double x = a.X-b.X;
         double y = a.Y-b.Y;
         return Math.Sqrt(x*x+y*y);
      }
      public static Point Add(Point a, Point b)
      {
         return new Point(a.X + b.X, a.Y + b.Y);
      }
      public static Point Subtract(Point a, Point b)
      {
         return new Point(a.X - b.X, a.Y - b.Y);
      }
