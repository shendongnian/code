    After you create a DataTable , you need to define its structure using columns.
    for eg.
    
    DataColumn column = new DataColumn(); 
    column.DataType = System.Type.GetType("System.Decimal"); 
    column.AllowDBNull = false; 
    column.Caption = "Price"; 
    column.ColumnName = "Price"; 
    column.DefaultValue = 25; 
    table.Columns.Add(column); 
