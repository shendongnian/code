    public static void Swap<T>(ref T x, ref T y)
    {
        T tmp = y;
        y = x;
        x = tmp;
    }
    private void Draw3DLine(int x0, int y0, int z0, int x1, int y1, int z1)
    {
        bool steepXY = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
        if (steepXY) { Swap(ref x0, ref y0); Swap(ref x1, ref y1); }
        bool steepXZ = Math.Abs(z1 - z0) > Math.Abs(x1 - x0);
        if (steepXZ) { Swap(ref x0, ref z0); Swap(ref x1, ref z1); }
        int deltaX = Math.Abs(x1 - x0);
        int deltaY = Math.Abs(y1 - y0);
        int deltaZ = Math.Abs(z1 - z0);
    
        int errorXY = deltaX / 2, errorXZ = deltaX / 2;
        int stepX = (x0 > x1) ? -1 : 1;  
        int stepY = (y0 > y1) ? -1 : 1;
        int stepZ = (z0 > z1) ? -1 : 1;
        int y=y0, z=z0;
        for(int x = x0; x<=x1; x+=stepX) 
        {
            int xCopy=x, yCopy=y, zCopy=z;
            if (steepXZ) Swap(ref xCopy, ref zCopy);
            if (steepXY) Swap(ref xCopy, ref yCopy);
            // Replace the WriteLine with your call to DrawOneBlock
            Console.WriteLine("[" + xCopy + ", " + yCopy + ", " + zCopy + "], ");
            errorXY -= deltaY;
            errorXZ -= deltaZ;
            if (errorXY < 0) 
            {
                y += stepY;
                errorXY += deltaX;
            }
            if (errorXZ < 0) 
            {
                z += stepZ;
                errorXZ += deltaX;
            }
        }
    }
