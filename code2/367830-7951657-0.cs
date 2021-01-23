        public static Array GetUnderlyingEnumValues(Type type)
        {
            Array values = Enum.GetValues(type);
            Type underlyingType = Enum.GetUnderlyingType(type);
            Array arr = Array.CreateInstance(underlyingType, values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                arr.SetValue(values.GetValue(i), i);
            }
            return arr;
        }
