    public static void ResizeArray<T>(
        ref T[,] array, int padLeft, int padRight, int padTop, int padBottom)
    {
        int ow = array.GetLength(0);
        int oh = array.GetLength(1);
        int nw = ow + padLeft + padRight;
        int nh = oh + padTop + padBottom;
        int x0 = padLeft;
        int y0 = padTop;
        int x1 = x0 + ow - 1;
        int y1 = y0 + oh - 1;
        int u0 = -x0;
        int v0 = -y0;
        
        if (x0 < 0) x0 = 0;
        if (y0 < 0) y0 = 0;
        if (x1 >= nw) x1 = nw - 1;
        if (y1 >= nh) y1 = nh - 1;
        T[,] nArr = new T[nw, nh];
        for (int y = y0; y <= y1; y++)
        {
            for (int x = x0; x <= x1; x++)
            {
                nArr[x, y] = array[u0 + x, v0 + y];
            }
        }
        array = nArr;
    }
