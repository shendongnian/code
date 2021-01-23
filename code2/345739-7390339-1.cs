       public static string GetStringValue(this Enum value) {
            // Get the type
            Type type = value.GetType();
            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());
            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];
            // Return the first if there was a match, or enum value if no match
            return attribs.Length > 0 ? attribs[0].StringValue : value.ToString();
        }
