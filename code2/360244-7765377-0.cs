        public static int GetPropertiesMaxLength(object obj)
        {
            int totalMaxLength = 0;
            Type type = obj.GetType();
            PropertyInfo[] info = type.GetProperties();
            foreach (PropertyInfo property in info)
            {
                var value = property.GetValue(obj, null) as string;
                if (!string.IsNullOrEmpty(value))
                {
                    totalMaxLength += value.Length;
                }
            }
            return totalMaxLength;
        }
