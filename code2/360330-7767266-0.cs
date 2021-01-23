    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> differenceList =
                new List<Point>()
                {
                    new Point(40, 60), 
                    new Point(10, 20),
                    new Point(20, 30), 
                    new Point(12, 61) };
            var q = from p1 in differenceList
                    from p2 in differenceList
                    let distance = Math.Abs(p1.X - p2.X)
                    where !object.ReferenceEquals(p1, p2)
                    select new { Point1 = p1, Point2 = p2, Distance = distance };
            var minimum = q.OrderBy(r => r.Distance).First();
            Console.WriteLine(
                "X difference = " +
                minimum.Distance +
                " (which is " +
                Math.Max(minimum.Point1.X, minimum.Point2.X) +
                " - " +
                Math.Min(minimum.Point1.X, minimum.Point2.X) + ")");
            Console.ReadLine();
        }
    }
