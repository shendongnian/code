    int imageWidth = 1024;
    int imageHeight = 1024;
    
    Color[] image = new Color[1024 * 1024];
    public void FloodFill(Point fillPosition, Color fillColor)
    {
        var pixelOffset = fillPosition.Y*imageWidth+fillPosition.X;
        /// read the color of the target pixel.
        var targetPixelColor = image[pixelOffset];
    
        /// can we fill here?
        if (targetPixelColor != fillColor)
        {
            image[pixelOffset] = fillColor;
            /// now try and fill the adjacent pixels.
            for (var i = fillPosition.X - 1; i <= fillPosition.X + 1; i++)
            {
                if (i>=0 && i<imageWidth)
                    for (var j = fillPosition.Y - 1; j <= fillPosition.Y + 1; j++)
                    {
                        /// don't try and fill *the input pixel again.
                        if (i != fillPosition.X && j != fillPosition.Y)
                        {
                            FloodFill(new Point(i, j), fillColor);
                        }
                    }
            }
        }
    
    }
