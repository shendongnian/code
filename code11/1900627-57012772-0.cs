    public class NumericConverter : IConvertFrom
    {
        public NumericConverter()
        {}
        public Boolean CanConvertFrom(Type sourceType)
        {
            return typeof(String) == sourceType;
        }
        public Object ConvertFrom(Object source)
        {
            String pattern = (String)source;
            PatternString patternString = new PatternString(pattern);
            String value = patternString.Format();
            return Int32.Parse(value);
        }
    }
