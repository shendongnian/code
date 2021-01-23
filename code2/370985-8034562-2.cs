    [TypeConverter(typeof (Color.ColorConverter))]
    public struct Color
    {
        private readonly byte alpha, red, green, blue;
        public Color(byte alpha, byte red, byte green, byte blue)
        {
            this.alpha = alpha;
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        public byte Alpha { get { return alpha; } }
        public byte Red { get { return red; } }
        public byte Green { get { return green; } }
        public byte Blue { get { return blue; } }
        public override string ToString()
        {
            return string.Format("{{(R,G,B,A) = ({0},{1},{2},{3})}}", Red, Green, Blue, Alpha);
        }
        private class ColorConverter : ExpandableObjectConverter
        {
            public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
            {
                return true;
            }
            public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
            {
                return new Color((byte)propertyValues["Alpha"], (byte)propertyValues["Red"],
                                 (byte) propertyValues["Green"], (byte) propertyValues["Blue"]);
            }
        }
    }
