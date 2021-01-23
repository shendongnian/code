    public static string ToCSV(DataTable tbl)
    {
        StringBuilder strb = new StringBuilder();
        //column headers
        strb.AppendLine(tbl.Columns.Cast<DataColumn>().Aggregate(
            (object x, object y) => x + "," + y).ToString());
        //rows
        tbl.AsEnumerable().Select(s => strb.AppendLine(
            s.ItemArray.Aggregate((x, y) => x + "," + y).ToString())).ToList();
        return strb.ToString();
    }
