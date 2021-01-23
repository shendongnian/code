        public static string GetDescription<T>(this object enumerationValue) where T : struct
        {
            // throw an exception if enumerationValue is not an Enum
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }
            //Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    //Pull out the description value
                    return attributes[0].Description;
                }
            }
            //In case we have no description attribute, we'll just return the ToString of the enum
            return enumerationValue.ToString();
        }
        public static T ParseEnum<T>(this string stringValue, T defaultValue)
        {
            // throw an exception if T is not an Enum
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be of Enum type", "T");
            }
            //Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] fields = type.GetFields();
            foreach (var field in fields)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0 && attributes[0].Description == stringValue)
                {
                    return (T)Enum.Parse(typeof(T), field.Name);
                }
            }
            //In case we couldn't find a matching description attribute, we'll just return the defaultValue that we provided
            return defaultValue;            
        }
