            public static bool TryGetValueFromAttribute<T>(this XElement element, String attName, out T output, T defaultValue)
        {
            var xAttribute = element.Attribute(attName);
            if (xAttribute == null)
            {
                output = defaultValue;
                return false;
            }
            if(typeof(T) == typeof(bool))
            {
                object value = XmlConvert.ToBoolean(xAttribute.Value);
                output = (T) value;
            
                return true;
            }
            output = (T)Convert.ChangeType(xAttribute.Value, typeof(T));
            return true;
        }
