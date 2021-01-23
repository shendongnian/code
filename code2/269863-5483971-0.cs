        public static string GetPropertyValue(this MyObject myObj, string propertyName)
        {
            var propInfo = typeof(MyObject).GetProperty(propertyName);
            if (propInfo != null)
            {
                return propInfo.GetValue(myObj, null).ToString();
            }
            else
            {
                return string.Empty;
            }
        }
