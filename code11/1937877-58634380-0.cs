    public class KeyConverter<T> : TypeConverter
        where T : struct, IEquatable<T>
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                if(int.TryParse(stringValue, out int parsed))
                {
                    return Activator.CreateInstance(typeof(T), new object[] { parsed });
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
  
