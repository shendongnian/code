    public static PointD[] CalculateVertices(int nSides, int nSideLength, PointD ptFirstVertex)
    {
        //calculate the points for a polygon of N sides
        if (nSides < 3)
            throw new ArgumentException("Polygons can't have less than 3 sides...");
        var aptsVertices = new PointD[nSides];
        var deg = (180.0 * (nSides - 2)) / nSides;
        var step = 360.0 / nSides;
        var rad = deg * (Math.PI / 180);
        double nSinDeg = Math.Sin(rad);
        double nCosDeg = Math.Cos(rad);
        aptsVertices[0] = ptFirstVertex;
        for (int i = 1; i < aptsVertices.Length; i++)
        {
            double x = aptsVertices[i - 1].X - nCosDeg * nSideLength;
            double y = aptsVertices[i - 1].Y - nSinDeg * nSideLength;
            aptsVertices[i] = new PointD(x, y);
            //recalculate the degree for the next vertex
            deg -= step;
            rad = deg * (Math.PI / 180);
            nSinDeg = Math.Sin(rad);
            nCosDeg = Math.Cos(rad);
        }
        return aptsVertices;
    }
