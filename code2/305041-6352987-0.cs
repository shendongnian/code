    DataTable dt = LoadDataTable()
    List<DataTable> splitTables = new List<DataTable>();
    for (int i = 0; i < dt.Rows.Count; i+=1000 )
    {
        splitTables.Add(dt.AsEnumerable().Skip(i).Take(1000).CopyToDataTable());
    }
