    class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Enum regulation = (Enum)value;
            return GetEnumDescription(regulation);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return String.Empty;
        }
        /// <summary>
        /// Returns text intended for display based on the Description Attribute of the enumeration value.
        /// If no Description Attribute is applied, the value is converted to a string and returned.
        /// </summary>
        /// <param name="enumObj">The enumeration value to be converted.</param>
        /// <returns>Text of the Description Attribute or the Enumeration itself converted to string.</returns>
        private string GetEnumDescription(Enum enumObj)
        {
            // Get the DescriptionAttribute of the enum value.
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            object[] attributeArray = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributeArray.Length == 0)
            {
                // If no Description Attribute was found, default to enum value conversion.
                return enumObj.ToString();
            }
            else
            {
                // Get the text of the Description Attribute
                DescriptionAttribute attrib = attributeArray[0] as DescriptionAttribute;
                return attrib.Description;
            }
        }
    }
