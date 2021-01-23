    public enum PrimaryColor
    {
        Red,
        Green,
        Blue
    }
    public struct Color
    {
        public byte r;
        public byte g;
        public byte b;
        public Color(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
