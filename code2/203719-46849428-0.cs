        public static object GetDBNullOrValue<T>(this T val)
        {
            bool isDbNull = true;
            Type t = typeof(T);
            if (Nullable.GetUnderlyingType(t) != null)
                isDbNull = EqualityComparer<T>.Default.Equals(default(T), val);
            else if (t.IsValueType)
                isDbNull = false;
            else if (t == typeof(string) && val != null)
            {
                string temp = val as String;
                isDbNull = (temp == String.Empty);
            }
            else
                isDbNull = (val == null);
            return isDbNull ? DBNull.Value : (object)val;
        }
