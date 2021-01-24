        public static T DBValue<T>(this object dbValue)
        {
            try
            {
                if (dbValue == DBNull.Value)
                    return default;
                return (T)dbValue;
            }
            catch (InvalidCastException)
            {
                return (T) Convert.ChangeType(dbValue, typeof(T));
            }
        }
