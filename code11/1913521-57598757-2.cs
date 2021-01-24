    [TypeConverter(typeof(Converter))]
    public class PhoneNumber
    {
        private readonly string _phoneNumber;
    
        public PhoneNumber(string phoneNumber)
        {
            _phoneNumber = _phoneNumber;
        }
    
        public static implicit operator PhoneNumber(string phoneNumber)
        {
            return new PhoneNumber(phoneNumber);
        }
    
        public static implicit operator string(PhoneNumber phoneNumber)
        {
            return phoneNumber.ToString();
        }
    
        public override string ToString()
        {
            return _phoneNumber;
        }
    
        public class Converter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string);
            }
    
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                return destinationType == typeof(string);
            }
    
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                return value.ToString();
            }
        }
    }
