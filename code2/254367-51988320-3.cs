        /// <summary>
        /// Returns the string value of the custom attribute property requested.
        /// </summary>
        public static string GetAttributeValue<TAttribute>(IConvertible @enum, string propertyName = "Value")
        {
            TAttribute attribute = GetAttribute<TAttribute>(@enum);
            return attribute == null ? null : attribute.GetType().GetProperty(propertyName).GetValue(attribute).ToString();
        }
        /// <summary>
        /// Returns a dictionary of all the Enum fields with the string of the property from the custom attribute nulls default to the enumName
        /// </summary>
        public static Dictionary<Enum, string> GetEnumStringReference<TEnum, RAttribute>(string propertyName = "Value")
        {
            Dictionary<Enum, string> _dict = new Dictionary<Enum, string>();
            Type enumType = typeof(TEnum);
            Type enumUnderlyingType = Enum.GetUnderlyingType(enumType);
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                string enumName = Enum.GetName(typeof(TEnum), enumValue);
                string decoratorValue = Common.GetAttributeValue<RAttribute>(enumValue, propertyName) ?? enumName;
                _dict.Add(enumValue, decoratorValue);
            }
            return _dict;
        }
