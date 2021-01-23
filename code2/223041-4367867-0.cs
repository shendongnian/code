    public static class EnumHelper
    {
        public static T GetEnumFromString<T>(string value)
        {
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            else
            {
                string[] enumNames = Enum.GetNames(typeof(T));
                foreach (string enumName in enumNames)
                {  
                    object e = Enum.Parse(typeof(T), enumName);
                    if (value == GetDescription((Enum)e))
                    {
                        return (T)e;
                    }
                }
            }
            throw new ArgumentException("The value '" + value 
                + "' does not match a valid enum name or description.");
        }
    }
