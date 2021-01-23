    public static class CoordinateConverter
    {
        public static RectangleF Convert(RectangleF source, RectangleF drawArea)
        {
            // I assume drawArea.X to be 0
            return new RectangleF(
                drawArea.Width - source.X - source.Width,
                source.Y,
                source.Width,
                source.Height);
        }
    
        public static RectangleF ConvertBack(Rectangle source, RectangleF drawArea)
        {
           return new RectangleF(
               source.X + source.Width - drawArea.Width,
               source.Y,
               source.Width,
               source.Height);
        }
    }
