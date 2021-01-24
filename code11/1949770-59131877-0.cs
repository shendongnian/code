cs
public class EnumMemberConverter<T> : EnumConverter {
    public EnumMemberConverter(Type type) : base(type) { }
    public override object ConvertFrom(ITypeDescriptorContext context, 
                                       CultureInfo culture, 
                                       object value) {
        var type = typeof(T);
        foreach (var field in type.GetFields()) {
            if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute &&
                value is string enumValue &&
                attribute.Value == enumValue) {
                return field.GetValue(null);
            }
        }
        return base.ConvertFrom(context, culture, value);
    }
}
usage:
cs
[TypeConverter(typeof(EnumMemberConverter<Cat>))]
public enum Cat {
    [EnumMember(Value = "white_cat")]
    WhiteCat,
    [EnumMember(Value = "black_cat")]
    BlackCat
}
