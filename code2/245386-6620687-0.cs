    [TypeConverter(typeof(EnumTypeConverter))]
    [Flags]
    public enum MyEnum
    {
        [Description("None representation")]
        None = 0,
        [Description("A representation")]
        A = 1,
        [Description("B representation")]
        B = 2,
    }
    public class EnumTypeConverter : EnumConverter
    {
        public EnumTypeConverter(Type enumType) : base(enumType) { }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null)
            {
                var enumType = value.GetType();
                if (enumType.IsEnum)
                    return GetDisplayName(value);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        private string GetDisplayName(object enumValue)
        {
            var displayNameAttribute =
                EnumType.GetField(enumValue.ToString()).GetCustomAttributes(typeof (DescriptionAttribute), false).
                    FirstOrDefault() as DescriptionAttribute;
            if (displayNameAttribute != null)
                return displayNameAttribute.Description;
            return Enum.GetName(EnumType, enumValue);
        }
    }
