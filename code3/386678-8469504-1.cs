    DataTable t = new DataTable();
    t.Columns.Add("Product", typeof(string));
    t.Columns.Add("Value", typeof(int));
    
    foreach(DataTable table in SampleDS.Tables)
    {
    if(table != null && table.Rows.Count > 0)
    {
    for(int i = 0; i < table.Rows.Count; i ++)
    t.ImportRow(table.Rows[i]);
    }
    }
