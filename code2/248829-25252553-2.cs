    public static string ToCSV(DataTable tbl)
    {
        StringBuilder strb = new StringBuilder();
        //column headers
        strb.AppendLine(string.Join(",", tbl.Columns.Cast<DataColumn>()
            .Select(s => "\"" + s.ColumnName + "\"")));
        //rows
        tbl.AsEnumerable().Select(s => strb.AppendLine(
            string.Join(",", s.ItemArray.Select(
                i => "\"" + i.ToString() + "\"")))).ToList();
        return strb.ToString();
    }
