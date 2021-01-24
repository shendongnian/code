    public static class DataRowExt {
        public static string SQLLiteral(this DataRow r, DataColumn c) {
            if (c.DataType == typeof(String))
                return $"\"{r.Field<string>(c.ColumnName)}\"";
            else if (c.DataType == typeof(DateTime))
                return $"\"{r.Field<DateTime>(c.ColumnName).ToString("yyyy-MM-dd HH:mm:ss.fff")}\"";
            else
                return r[c.ColumnName].ToString();
        }
    
        public static string SQLLiteral(this DataTable dt) =>
            String.Join("\nUNION ALL\n", dt.AsEnumerable().Select(r => "SELECT " + String.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => $"{r.SQLLiteral(c)} AS [{c.ColumnName}]"))));
    }
