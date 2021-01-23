    public static class EnumExtender
    {
        public static string StringValue(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            EnumStringValueAttribute[] attributes = (EnumStringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumStringValueAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Value;
            }
            return value.ToString();
        } 
    }
    public class EnumStringValueAttribute : Attribute
    {
        public string Value { get; set; }
        public EnumStringValueAttribute(string value) : base()
        {
            this.Value = value;
        }
    }
