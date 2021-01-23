        public static object ParamValue<T>(Enum value)
        {
            if (value == null)
                return System.DBNull.Value;
            else
                return (T)Enum.Parse(value.GetType(), value.ToString());
        }
