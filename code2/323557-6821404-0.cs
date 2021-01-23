You can store the datatables in a Dictionary
    var allDataTables = new Dictionary<string, DataTable>();
    if (allDataTables.Contains("DataTableA"))
    {
       var dataTableA = allDataTables["DataTableA"];
       //work with datatable A
    }
    
