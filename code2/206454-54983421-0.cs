    public static object GetValueSafely<T>(this System.Data.DataTable dt, string ColumnName, int index)
    {
        if (typeof(T) == typeof(int))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return 0;
        }
        else if (typeof(T) == typeof(double))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return 0;
        }
        else if (typeof(T) == typeof(decimal))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return 0;
        }
        else if (typeof(T) == typeof(float))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return 0;
        }
        else if (typeof(T) == typeof(string))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return string.Empty;
        }
        else if (typeof(T) == typeof(byte))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return 0;
        }
        else if (typeof(T) == typeof(DateTime))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return DateTime.MinValue;
        }
        else if (typeof(T) == typeof(bool))
        {
            if (dt.Rows[index][ColumnName] != DBNull.Value)
                return dt.Rows[index][ColumnName];
            else
                return false;
        }
        if (dt.Rows[index][ColumnName] != DBNull.Value)
            return dt.Rows[index][ColumnName];
        else
            return null;
    }
