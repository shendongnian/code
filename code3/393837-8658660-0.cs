    List<DataTable> aCopy = new List<DataTable>(); 
    for(int i = 0; i < a.Rows.Count; i++) { 
       DataTable sourceTable = a[i];
       DataTable copyTable = sourceTable.Clone(); //Clones structure
       copyTable.Load(sourceTable.CreateDataReader());
    } 
