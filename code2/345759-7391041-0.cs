    public void GetMinMaxRangeTest(DataTable data, string valueColumnName)
    {
        DataColumn column = data.Columns[valueColumnName];
        var min = data.AsEnumerable().Min(m => Convert.ChangeType(m[valueColumnName], column.DataType));
        var max = data.AsEnumerable().Max(m => Convert.ChangeType(m[valueColumnName], column.DataType));
    }
