    private DataTable CreateDataTable()
    {
    DataTable myDataTable = new DataTable();
    
    DataColumn myDataColumn; 
    
    myDataColumn = new DataColumn();
    myDataColumn.DataType = Type.GetType("System.String");
    myDataColumn.ColumnName = "id";
    myDataTable.Columns.Add(myDataColumn);
    
    myDataColumn = new DataColumn();
    myDataColumn.DataType = Type.GetType("System.String");
    myDataColumn.ColumnName = "username";
    myDataTable.Columns.Add(myDataColumn);
    
    myDataColumn = new DataColumn();
    myDataColumn.DataType = Type.GetType("System.String");
    myDataColumn.ColumnName = "firstname";
    myDataTable.Columns.Add(myDataColumn);
    
    myDataColumn = new DataColumn();
    myDataColumn.DataType = Type.GetType("System.String");
    myDataColumn.ColumnName = "lastname";
    myDataTable.Columns.Add(myDataColumn);
    
    return myDataTable;
    }
