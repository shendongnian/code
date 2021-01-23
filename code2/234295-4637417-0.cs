        public static T Get<T>(this DataRow row, string field)  
        {
            if (row != null && row.Table.Columns.Contains(field))
            {
                object value = row[field];
                if (value != null && value != DBNull.Value)
                    return (T)Convert.ChangeType(value, typeof(T));
            }
            return default(T);
        }
