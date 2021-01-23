    public static string ToCsv(this DataTable table, string colSep = "", string rowSep = "\r\n")
    {
        var format = string.Join(colSep, Enumerable.Range(0, table.Columns.Count)
												.Select(i => string.Format("{{{0}}}", i)));
        return string.Join(rowSep, table.Rows.OfType<DataRow>()
											.Select(i => string.Format(format, i.ItemArray)));
    }
