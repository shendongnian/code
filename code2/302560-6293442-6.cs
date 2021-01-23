        /// <summary>
        /// Gets a string value for a particular enum value.
        /// </summary>
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            if (StringValues.ContainsKey(value))
            {
                output = ((StringValueAttribute) StringValues[value]).Value;
            }
            else
            {
                //Look for our 'StringValueAttribute' in the field's custom attributes
                FieldInfo fi = type.GetField(value.ToString());
                var attributes = fi.GetCustomAttributes(typeof(StringValueAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = (StringValueAttribute) attributes[0];
                    StringValues.Add(value, attribute);
                    output = attribute.Value;
                }
            }
            return output;
        }
