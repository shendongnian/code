    public class Color
    {
        private readonly string _color;
    
        public Color(string color)
        {
            _color = color;
        }
    
        public override string ToString()
        {
            return _color;
        }
    }
    
    public class Size
    {
        private readonly string _size;
    
        public Size(string size)
        {
            _size = size;
        }
    
        public override string ToString()
        {
            return _size;
        }
    }
    
    public class Material
    {
        private readonly string _material;
    
        public Material(string material)
        {
            _material = material;
        }
    
        public override string ToString()
        {
            return _material;
        }
    }
