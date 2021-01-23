    public class MimeFormatElement : ConfigurationElement
    {
        [TypeConverter(typeof(MimeFormatConverter))]
        public string Format
        {
            get { return ... }
            set { ... }
        }
    }
***
    public class MimeFormatConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(string));
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string val = (string)value;
            var parts = val.Split('/');
            if (parts.Length != 2)
            {
                throw new Exception("Invalid MimeFormat");
            }
            return new MimeFormat(parts[0], parts[1]);
        }
    
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (sourceType == typeof(string));
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            MimeFormat val = (MimeFormat)value;
            return val.Type + '/' + val.SubType;
        }
    }
