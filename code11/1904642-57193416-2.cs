    public static DataTable CutDataTable(DataTable dt, IList<string> columnsToRemove,
                                         bool keepData = true)
    {
        DataTable newDt = (keepData ? dt.Copy() : dt.Clone());
        foreach (string colName in columnsToRemove)
        {
            if (!newDt.Columns.Contains(colName)) continue;
            newDt.Columns.Remove(colName);
        }
        return newDt;
    }
