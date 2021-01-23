    DataTable dt = new DataTable();
    
    dt.Columns.Add("Id",typeof(int));
    
    dt.Columns.Add("Name",typeof(string));
    
    dt.Columns.Add("BlaBla",typeof(string));
    
    dt.AcceptChanges();
    // Your DB Connection codes.
    
    while(dr.Read())
    
    {
    object[] row = new object[]()
    
    {
    dr[0].ToString(),// ROW 1 COLUMN 0 
    
    dr[1].ToString(),// ROW 1 COLUMN 1
    
    dr[2].ToString(),// ROW 1 COLUMN 2
    
    }
    
    dt.Rows.Add(row);
    
    }
