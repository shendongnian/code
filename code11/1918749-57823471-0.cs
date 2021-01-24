    public class SomeClass
    {
        public int Key { get; set; }
        [TypeConverter(typeof(LookupConverter))]
        public Guid LookupKey { get; set; }
    }
    public class LookupConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string)) //property grid will ask for this
            {
                var key = (Guid)value;
                return ConvertGuidToDescription(...) // TODO: implement this
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
