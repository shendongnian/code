    public static class DrawableExtensions
    {
        public static int CalculateSize(this IDrawable drawable)
        {
             return drawable.Width * drawable.Height;
        }
    }
