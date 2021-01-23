        public static List<T> GetList<T>(Type enumType)
        {
            List<T> output = new List<T>();
            var fields = from field in enumType.GetFields()
                         where field.IsLiteral
                         select field;
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(enumType);
                output.Add((T) value);
            }
            return output;
        }
