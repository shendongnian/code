    private static T GetEnumValue<T>(string description)
    {
        // get all public static fields from the enum type
        FieldInfo[] ms = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
        foreach (FieldInfo field in ms)
        {
            // pull out the DescriptionAttribute (if any) from the field
            var descriptionAttribute = field
                .GetCustomAttributes(typeof(DescriptionAttribute), true)
                .FirstOrDefault();
            // Check if there was a DescriptionAttribute, and if the 
            // description matches
            if (descriptionAttribute != null
                && (descriptionAttribute as DescriptionAttribute).Description
                        .Equals(description, StringComparison.OrdinalIgnoreCase))
            {
                // return the field value
                return (T)field.GetValue(null);
            }
        }
        return default(T);
    }
