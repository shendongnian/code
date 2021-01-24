    public static DataTable MergeDataTable(DataTable dt1, DataTable dt2)
    {
        DataTable newDt = new DataTable();
        List<DataRow> rows = dt1.Rows.OfType<DataRow>().ToList();
        rows.AddRange(dt2.Rows.OfType<DataRow>().ToList());
        foreach (DataRow dataRow in rows)
        {
            newDt.Rows.Add(dataRow);
        }
        return newDt;
    }
