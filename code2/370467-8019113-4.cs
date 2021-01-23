        public static int GetPropertyMaxLength(PropertyInfo property)
        {
            CustomStringFormatAttribute attrib = Attribute.GetCustomAttribute(property, typeof(CustomStringFormatAttribute)) as CustomStringFormatAttribute;
            return attrib != null ? attrib.MaxLength : int.MaxValue;
        }
        public static int GetPropertyMaxLength(Type type, string propertyName)
        {
            return GetPropertyMaxLength(type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance));
        }
