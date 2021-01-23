    public class FooTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(string));
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string val = value as string;
            if (val != null)
            {
                string[] parts = val.Split(',');
                if (parts.Length != 2)
                {
                    // Throw an exception
                }
                return new Foo { First = parts[0], Second = parts[1] };
            }
            return null;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(string));
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            Foo val = value as Foo;
            if (val != null)
                return val.ToString();
            return null;
        }
    }
