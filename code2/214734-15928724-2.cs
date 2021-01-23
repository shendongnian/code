    private static object GetDataValue(object value)
            {
                if (value == null || (value.GetType() == typeof(DateTime) && Convert.ToDateTime(value) == DateTime.MinValue) || (value.GetType() == typeof(DateTime) && Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1753")))
                {
                    return DBNull.Value;
                }
    
                return value;
            }
