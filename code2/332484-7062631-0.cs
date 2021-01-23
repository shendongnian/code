        public static Array GetValues(Type type)
        {
            var fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
            Array result = Array.CreateInstance(type, fields.Length);
            for(int i = 0 ; i < fields.Length ; i++)
            {
                result.SetValue(Enum.ToObject(type, fields[i].GetValue(null)), i);
            }
            return result;
        }
