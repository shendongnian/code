        public static string FormatProperty(object instance, PropertyInfo property)
        {
            CustomStringFormatAttribute attrib = Attribute.GetCustomAttribute(property, typeof(CustomStringFormatAttribute)) as CustomStringFormatAttribute;
            return property.GetValue(instance, null).ToString().PadLeft(attrib.MaxLength, ' ');
        }
        public static string FormatProperty(object instance, string propertyName)
        {
            return FormatProperty(instance, instance.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance));
        }
