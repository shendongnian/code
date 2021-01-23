    public class ConnectionStringTypeConverter : TypeConverter
        {
          public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
          {
            return ConfigurationManager.ConnectionStrings[value.ToString()];
          }
        }
