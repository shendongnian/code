    public static string GetDescription(this Enum enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString())
                .GetCustomAttributes(typeof (DescriptionAttribute), false);
            return (attr.Length > 0) 
                ? ((DescriptionAttribute) attr[0]).Description 
                : String.Empty;            
        }
