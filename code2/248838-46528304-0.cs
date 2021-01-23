    public static string Convert(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
    
        IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                            Select(column => column.ColumnName);
        sb.AppendLine(string.Join(",", columnNames));
    
        foreach (DataRow row in dt.Rows)
        {
            IEnumerable<string> fields = row.ItemArray.Select(field =>
            {
                string s = field.ToString().Replace("\"", "\"\"");
                if(s.Contains(','))
                    s = string.Concat("\"", s, "\"");
                return s;
            });
            sb.AppendLine(string.Join(",", fields));
        }
    
        return sb.ToString().Trim();
    }
