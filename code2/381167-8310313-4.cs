    IDataGridColumnData instance = GetDataGridColumnData(
        Type.GetType("System.Int32"),
        Type.GetType("System.String"));
    
    // use the properties
    instance.SearchColumnAsObject = 42; // works well
    instance.SearchColumnAsObject = "42"; // throws exception
