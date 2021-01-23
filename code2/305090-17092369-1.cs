    public static class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attr = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attr.Length > 0)
            {
                output = attr[0].Value;
            }
            return output;
        }
    }
