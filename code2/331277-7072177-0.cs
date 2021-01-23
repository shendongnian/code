        // Figure out the final size
        int maxX = 0;
        int maxY = 0;
        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                System.Drawing.Color c = bitmap.GetPixel(x, y);
                System.Drawing.Color w = System.Drawing.Color.White;
                if (c.R != w.R || c.G != w.G || c.B != w.B)
                {
                    if (x > maxX)
                        maxX = x;
                    if (y > maxY)
                        maxY = y;
                }
            }
        }
        maxX += 2;
