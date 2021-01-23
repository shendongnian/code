    Point p1 = new Point(1, 1);
    Point p2 = new Point(3, 3);
    int dx = Math.Sign(p2.X - p1.X);
    int dy = Math.Sign(p2.Y - p1.Y);
    
    for (int x = p1.X; x != p2.X + dx; x += dx)
    {
        for (int y = p1.Y; y != p2.Y + dy; y += dy)
        {
            Console.WriteLine("{0} {1}", x, y);
        }
    }
