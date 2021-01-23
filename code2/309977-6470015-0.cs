    [TypeConverter(typeof(CustomSettingConverter))]
    public class CustomSetting
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public override string ToString()
        {
            return string.Format("{0};{1}", Foo, Bar);
        }
    }
    public class CustomSettingConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if( sourceType == typeof(string) )
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            string stringValue = value as string;
            if( stringValue != null )
            {
                // Obviously, using more robust parsing in production code is recommended.
                string[] parts = stringValue.Split(';');
                if( parts.Length == 2 )
                    return new CustomSetting() { Foo = parts[0], Bar = parts[1] };
                else
                    throw new FormatException("Invalid format");
            }
            else
                return base.ConvertFrom(context, culture, value);
        }
    }
