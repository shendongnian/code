    public class MimeFormatElement: ConfigurationElement
    {
        #region Constructors
        /// <summary>
        /// Predefines the valid properties and prepares
        /// the property collection.
        /// </summary>
        static MimeFormatElement()
        {
            // Predefine properties here
            _mimeFormat = new ConfigurationProperty(
                "mimeFormat",
                typeof(MimeFormat),
                "*/*",
                ConfigurationPropertyOptions.IsRequired
            );
   
            _properties = new ConfigurationPropertyCollection {
                _mimeFormat, _enabled
            };
        }
        private static ConfigurationProperty _mimeFormat;
        private static ConfigurationPropertyCollection _properties;
        [ConfigurationProperty("mimeFormat", IsRequired = true)]
        public MimeFormat MimeFormat
        {
            get { return (MimeFormat)base[_mimeFormat]; }
        }
    }
    /*******************************************/
    [TypeConverter(typeof(MimeFormatConverter))]
    /*******************************************/
    public class MimeFormat
    {
        public string Format
        {
            get
            {
                return Type + "/" + SubType;
            }
        }
        public string Type;
        public string SubType;
    
        public MimeFormat(string mimeFormatStr)
        {
            var parts = mimeFormatStr.Split('/');
            if (parts.Length != 2)
            {
                throw new Exception("Invalid MimeFormat");
            }
            Type = parts[0];
            SubType = parts[1];
        }
    }
    public class MimeFormatConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return new MimeFormat((string)value);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var val = (MimeFormat)value;
            return val.Type + "/" + val.SubType;
        }
    }
