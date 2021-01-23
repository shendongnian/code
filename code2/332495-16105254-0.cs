        public static Array GetEnumValues(this Type enumType)
        {
            List<int> enumerations = new List<int>();
            FieldInfo[] fields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
            object enumObj = enumType.GetType();
            foreach (FieldInfo fieldInfo in fields)
            {
                enumerations.Add((int)fieldInfo.GetValue(enumObj));
            }
            return enumerations.ToArray();
        }
