    public enum MyEnum
    {
        [Description("My first value.")]
        FirstValue,
        [Description("My second value.")]
        SecondValue,
        [Description("My third value.")]
        ThirdValue
    }
    private string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return value.ToString();
        }
    }
