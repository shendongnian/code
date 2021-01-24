    [TypeConverter(typeof(MyEnumConverter))]
    public enum TestEnum
    {
        a = 1,
        b = 2,
        c = 4
    }
    public class MyEnumConverter : EnumConverter
    {
        public MyEnumConverter(Type type)
            : base(type)
        {
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            try
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            catch
            {
                if (destinationType == typeof(string))
                {
                    // or whatever you see fit
                    return "a";
                }
                throw;
            }
        }
    }
