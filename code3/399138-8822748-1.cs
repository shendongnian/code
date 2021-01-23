    public class SizeRangeConverter : TypeConverter {
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
        if (sourceType == typeof(string))
          return true;
        return base.CanConvertFrom(context, sourceType);
      }
      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
        if (value is string) {
          string[] v = ((string)value).Split(',');
          Byte? minValue = null;
          Byte? maxValue = null;
          Byte minTest;
          Byte maxTest;
          if (byte.TryParse(v[0], out minTest))
            minValue = minTest;
          if (byte.TryParse(v[1], out maxTest))
            maxValue = maxTest;
          return new SizeRange(minValue, maxValue);
        }
        return base.ConvertFrom(context, culture, value);
      }
      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
        if (destinationType == typeof(string))
          return ((SizeRange)value).ToString();
        return base.ConvertTo(context, culture, value, destinationType);
      }
    }
