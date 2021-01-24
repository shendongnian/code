static void Main(string[] args)
{
    List<Point> points = new List<Point>
    {
        new Point(3, 4),
        new Point(5, 4),
        new Point(5, 1)
    };
    Point closestPoint = points.OrderBy(point => point.DistanceFromPoint(new Point(1, 1))).FirstOrDefault();
    Console.WriteLine($"The closest point to 1,1 is {closestPoint.PosX},{closestPoint.PosY}");
    Console.ReadLine();
}
private class Point
{
    public Point(int posX, int posY)
    {
        PosX = posX;
        PosY = posY;
    }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public double DistanceFromPoint(Point otherPoint)
    {
        return Math.Sqrt(Math.Pow((otherPoint.PosX - PosX), 2) + Math.Pow((otherPoint.PosY - PosY), 2));
    }
}
