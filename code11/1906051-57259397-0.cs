    DataTable dt = GetIssues(fmWeb); 
    ds.Tables.Add(dt);
    
    public static DataTable CustomMerge(DataSet ds)
    {
    DataTable MergedDataTable = new DataTable();
    DataView dv;
    List<string> columnName= new List<string>();
    for (int i = 0; i < ds.Tables.Count; i++)
    {
    MergedDataTable.Merge(ds.Tables[i]);
    }
    for (int i = 0; i < MergedDataTable.Columns.Count; i++)
    {
    columnName.Add(MergedDataTable.Columns[i].ColumnName);
    }
    dv = new DataView(MergedDataTable);
    return dv.ToTable(true, columnName.ToArray<string>());
    }
