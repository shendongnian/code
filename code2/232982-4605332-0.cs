    foreach (DataColumn dc in dtNewTable.Columns)
    {
        if (dc.ColumnName == "MONTH")
        {
            dc.DataType = typeof(String);
        }
    }
