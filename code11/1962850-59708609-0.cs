    public void MakeDisk(int radius, int x0, int y0)
    {
        int x = 0;
        int y = radius;
        double d = 5 / 4.0 - radius;
        for (int ty=y; ty>=x; --ty) {
            SelectSymmetry(x, ty, x0, y0);
        }
        while (x < y)
        {
            x++;
            if (d < 0)
            {
                d += 2 * x + 1;
            }
            else
            {
                y--;
                d += 2 * (x - y) + 1;
            }
            for (int ty=y; ty>=x; --ty) {
                SelectSymmetry(x, ty, x0, y0);
            }
        }
    }
