    public static DataTable ToDataTable(this List<List<string>> list)
    {
        DataTable dt = new DataTable();
        list.First().ForEach(colname => dt.Columns.Add(colname));
        foreach (List<string> row in list.Skip(1))
            dt.Rows.Add(row.ToArray());
        return dt;
    }
