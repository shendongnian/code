    private DataTable RemoveDuplicatesRecords(DataTable dt)
    {
        //Returns just 5 unique rows
        var UniqueRows = dt.AsEnumerable().Distinct(DataRowComparer.Default);
        DataTable dt2 = UniqueRows.CopyToDataTable();
        return dt2;
    }
