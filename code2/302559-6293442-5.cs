        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value (case sensitive).
        /// </summary>
        public static object Parse(Type type, string stringValue)
        {
            return Parse(type, stringValue, false);
        }
        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value.
        /// </summary>
        public static object Parse(Type type, string stringValue, bool ignoreCase)
        {
            object output = null;
            string enumStringValue = null;
            if (!type.IsEnum)
            {
                throw new ArgumentException(String.Format("Supplied type must be an Enum.  Type was {0}", type));
            }
            //Look for our string value associated with fields in this enum
            foreach (FieldInfo fi in type.GetFields())
            {
                //Check for our custom attribute
                var attrs = fi.GetCustomAttributes(typeof (StringValueAttribute), false) as StringValueAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    enumStringValue = attrs[0].Value;
                }			            
                //Check for equality then select actual enum value.
                if (string.Compare(enumStringValue, stringValue, ignoreCase) == 0)
                {
                    output = Enum.Parse(type, fi.Name);
                    break;
                }
            }
            return output;
        }
