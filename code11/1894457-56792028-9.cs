    public class MyEnumConverter: EnumConveter {
        public MyEnumConverter(Type type) : base(type) {
        }
    
        
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                var enumString = (string)value;
                return EnumExtensions.GetValueFromDescription(enumString, EnumType);
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
