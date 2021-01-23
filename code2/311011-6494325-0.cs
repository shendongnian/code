       class Circle
    {
        public const double PI = 3.14;
        private Color _color;
        int radius;
        public Circle(Color Color,int radius)
        {
            _color = Color;
            this.radius = radius;
        }
    
       public Color Color { return _color; }
    }
    
    public enum Color { Black, Yellow, Blue, Green }
