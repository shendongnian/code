    Color[,] c = GetSection(myImage, new Rectangle(0, 0, 100, 100)); // Get the upper-left 100x100 pixel block in the image myImage
    for (int x = 0; x < c.GetUpperBound(0); x++)
    {
        for (int y = 0; y < c.GetUpperBound(1); y++)
        {
            Color thePixel = c[x, y];
            // do something with the color
        }
    }
