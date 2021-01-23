        public static T GetValueOrDefault<T>(this object value) {
            if (value == DBNull.Value) {
                return default(T);
            }
            else {
                if (typeof(T).IsEnum) value = Enum.ToObject(typeof(T), Convert.ToInt64(value));
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }
