    public static bool IsPresent(DataView dvDataTag, string colName)
    {
        return dvDataTag.Table.Columns.Cast<DataColumn>().
                                          Any(c => c.ColumnName == colName);
    }
