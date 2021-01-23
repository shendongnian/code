    public static void WriteCsv(DataTable dt, string path)
    {
        using (var writer = new StreamWriter(path)) {
            writer.WriteLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(dc => dc.ColumnName)));
            foreach (DataRow row in dt.Rows) {
                writer.WriteLine(string.Join(",", row.ItemArray));
            }
        }
    }
