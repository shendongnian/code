    public enum Color
    {
        Black, Yellow, Blue, Green
    }
    
    class Circle
    {
        public const double PI = 3.14;
        public Color Color { get; private set; }
    
        int radius;
    
        public Circle( int radius,Color color)
        {
            this.radius = radius;
            this.Color = color;
        }
    }
