    // Convert a DataRow to a MyData:
    public static MyData ToMyData(this DataRow row)
    {
        // Todo: check for null row
        return new MyData
        {
            OptionId = row... // TODO implement
            ...
        }
    }
    // Convert a sequence of DataRows to a sequence of MyData
    public static IEnumerable<MyData> ToMyData(this IEnumerable<DataRow> rows)
    {
        // TODO: check for null rows
        return rows.Select(row => row.ToMyData());
    }
    // Convert a DataTable to a sequence of MyData:
    public static IEnumerable<MyData> ToMyData(this DataTable table)
    {
         // TODO: check for null table
         return table.Rows.Cast<DataRow>().ToMyData();
    }
