    public void FloodFill(Point clickPosition, Color fillColor)
    {
        var backgroundColor = GetPixel(clickPosition);
    
        RecurseFloodFill(clickPosition,fillColor,backgroundColor);
    }
    
    private void RecurseFloodFill(Point fillPosition, Color fillColor, Color backgroundColor)
    {
        var targetPixelColor = GetPixel(fillPosition);
    
        /// can we fill here?
        if (targetPixelColor == backgroundColor)
        {
            SetPixel(fillPosition, fillColor);
            /// now try and fill the adjacent pixels.
            for (var i = fillPosition.X - 1; i <= fillPosition.X + 1; i++)
            {
                if (i>=0 && i<imageWidth)
                    for (var j = fillPosition.Y - 1; j <= fillPosition.Y + 1; j++)
                    {
                        /// don't try and fill *the input pixel again.
                        if (i != fillPosition.X && j != fillPosition.Y)
                        {
                            RecurseFloodFill(new Point(i, j), fillColor,backgroundColor);
                        }
                    }
            }
        }
    
    }
