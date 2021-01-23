    public static class RectangleExtensions 
    {
        public static Rectangle MultiplyBy(this Rectangle rect, Vector2 scale)
        {
            return new Rectangle(//...
        }
        public static Rectangle MultiplyBy(this Vector2 scale, Rectangle rect) 
        {
            return new Rectangle(//...
        }
    }
    // using it
    Rectangle output = yourRect.MultiplyBy(yourVector);
