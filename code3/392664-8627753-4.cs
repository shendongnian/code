    NativeMethods.Point[] points;
    int size;
    int result = NativeMethods.GetPoints(out points, out size);
    if (result == 0)
    {
        Console.WriteLine("{0} points returned.", size);
        foreach (NativeMethods.Point point in points)
        {
            Console.WriteLine("({0}, {1}, {2})", point.x, point.y, point.z);
        }
    }
