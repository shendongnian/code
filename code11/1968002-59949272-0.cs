    public static void Main()
    {
        Point p1 = new Point(...);
        Point p2 = new Point(...);
        Point p3 = new Point(...);
        List<Point> points = new List<Point> { p1, p2, p3 };
        CalculateSomething(points, point => point.firstParameter);
    }
