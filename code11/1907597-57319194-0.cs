    public class TupleConverter<T1, T2>: TypeConverter 
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context,CultureInfo culture, object value)
        {
            var elements = Convert.ToString(value).Trim('(').Trim(')').Split(new[] {','},StringSplitOptions.RemoveEmptyEntries);
            return (elements.First(),elements.Last());
        }
    }
