    public static Point[] CalculateVertices(int nSides, int nSideLength, Point ptFirstVertex)
    {
        if (nSides < 3)
            throw new ArgumentException("Polygons can't have less than 3 sides...");
        var aptsVertices = new Point[nSides];
        var deg = ((double)180 * (nSides - 2)) / nSides;
        var step = 360 / nSides;
        var rad = deg * (Math.PI / 180);
    
        double nSinDeg = Math.Sin(rad);
        double nCosDeg = Math.Cos(rad);
    
        aptsVertices[0] = ptFirstVertex;
    
        for (int i = 1; i < aptsVertices.Length; i++)
        {
            double x = aptsVertices[i - 1].X - nCosDeg * nSideLength;
            double y = aptsVertices[i - 1].Y - nSinDeg * nSideLength;
            aptsVertices[i] = new Point((int)x, (int)y);
    
    
            //recalculate the degree for the next vertex
            deg -= step;
            rad = deg * (Math.PI / 180);
    
            nSinDeg = Math.Sin(rad);
            nCosDeg = Math.Cos(rad);
    
        }
        return aptsVertices;
    }
