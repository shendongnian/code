    private static string GetEnumCustomValue(Enum value)
    {
       FieldInfo enumField = value.GetType().GetField(value.ToString());
       var attributes = 
          (DescriptionAttribute[])enumField.GetCustomAttributes(typeof(DescriptionAttribute)), false);
       if (attributes.Length > 0)
       {
          return attributes[0].Description;
       }
       return value.ToString();
    }
