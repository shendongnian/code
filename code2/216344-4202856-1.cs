    private static string GetEnumCustomValue(Enum value)
    {
       FieldInfo enumField = value.GetType().GetField(value.ToString());
       var attributes = 
          (DescriptionAttribute[])enumField.GetCustomAttributes(typeofDescriptionAttribute), false);
       if (attributes.Length > 0)
       {
          return attributes[0].Description;
       }
       return value.ToString();
    }
