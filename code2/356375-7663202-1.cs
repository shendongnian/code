    public struct Colour 
    {
        private byte red;
        private byte green;
        private byte blue;
        public Colour(byte r, byte g, byte b) 
        {
            this.red = r;
            this.green = g;
            this.blue = b;
        }
    }
    
    public class Shape
    {
        public Colour Colour { get; private set; }
    
        public Shape(Colour c)
        {
            this.Colour = c;
        }
    }
    
