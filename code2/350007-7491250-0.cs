            public static object enumValueOf(string description, Type enumType)
            {
                string[] names = Enum.GetNames(enumType);
                foreach (string name in names)
                {
                    if (descriptionValueOf((Enum)Enum.Parse(enumType, name)).Equals(description))
                    {
                        return Enum.Parse(enumType, name);
                    }
                }
    
                throw new ArgumentException("The string is not a description of the specified enum.");
            }
 
            public static string descriptionValueOf(Enum value)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[]) fi.GetCustomAttributes( typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                else
                {
                    return value.ToString();
                }
            }
