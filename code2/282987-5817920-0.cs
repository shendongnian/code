    void Main()
    {
        int[,] linePoints =
        {
            { -3, -3 },
            { -2, -2 },
            { -1, -1 },
            { 0, 0 },
            { 1, 1 },
            { 2, 2 },
            { 3, 3 },
        };
        int N = 2;
        int M = 2;
        
        // start of the code you're asking for
        int width = linePoints.GetLength(1);
        int newHeight = linePoints.GetLength(0) - (N + M);
        int[,] newLinePoints = new int[newHeight, width];
        
        for (int y = 0; y < newHeight; y++)
            for (int x = 0; x < width; x++)
                newLinePoints[y, x] = linePoints[N + y, x];
        // end of the code you're asking for
                
        linePoints.Dump();
        newLinePoints.Dump();
    }
