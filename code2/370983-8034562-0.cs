    [TypeConverter(typeof (Color.ColorConverter))]
    public class Color
    {
        public int Alpha { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public override string ToString()
        {
            return string.Format("{{(R,G,B,A) = ({0},{1},{2},{3})}}", Red, Green, Blue, Alpha);
        }
        private class ColorConverter : ExpandableObjectConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) ? false : base.CanConvertFrom(context, sourceType);
            }
        }
    }
