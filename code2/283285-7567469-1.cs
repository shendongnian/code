        public static string GetString(this Enum value)
        {
            EnumResourceAttribute ea =
           (EnumResourceAttribute)value.GetType().GetField(value.ToString())
            .GetCustomAttributes(typeof(EnumResourceAttribute), false)
             .FirstOrDefault();
            if (ea != null)
            {
                PropertyInfo pi = ea.ResourceType
                 .GetProperty(CommonConstants.ResourceManager);
                if (pi != null)
                {
                    ResourceManager rm = (ResourceManager)pi
                    .GetValue(null, null);
                    return rm.GetString(ea.ResourceName);
                }
            }
            return string.Empty;
        }
        public static IList GetStrings(this Type enumType)
        {
            List<string> stringList = new List<string>();
            FieldInfo[] fiArray = enumType.GetFields();
            foreach (FieldInfo fi in fiArray)
            {
                EnumResourceAttribute ea =
                    (EnumResourceAttribute)fi
                         .GetCustomAttributes(typeof(EnumResourceAttribute), false)
                         .FirstOrDefault();
                if (ea != null)
                {
                    PropertyInfo pi = ea.ResourceType
                                        .GetProperty(CommonConstants.ResourceManager);
                    if (pi != null)
                    {
                        ResourceManager rm = (ResourceManager)pi
                                              .GetValue(null, null);
                        stringList.Add(rm.GetString(ea.ResourceName));
                    }
                }
            }
            return stringList.ToList();
        }
    }
