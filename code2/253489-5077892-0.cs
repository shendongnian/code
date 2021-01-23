    var firstTable = new DataTable();
    firstTable.Columns.Add(new DataColumn("FirstTableId", typeof(int)));
    firstTable.Columns.Add(new DataColumn("FirstTableName", typeof(string)));
    firstTable.Columns.Add(new DataColumn("SecondTableId", typeof(int)));
    
    var secondTable = new DataTable();
    secondTable.Columns.Add(new DataColumn("SecondTableId", typeof(int)));
    secondTable.Columns.Add(new DataColumn("SecondTableName", typeof(string)));
    
    var joinedTable = new DataTable();
    joinedTable.Columns.Add(new DataColumn("FirstTableId", typeof(int)));
    joinedTable.Columns.Add(new DataColumn("FirstTableName", typeof(string)));
    joinedTable.Columns.Add(new DataColumn("SecondTableId", typeof(int)));
    joinedTable.Columns.Add(new DataColumn("SecondTableName", typeof(string)));
    
    joinedTable.Rows.Add(1, "FirstTableRow1", 1, "SecondTableRow1");
    joinedTable.Rows.Add(2, "FirstTableRow2", 1, "SecondTableRow1");
    joinedTable.Rows.Add(3, "FirstTableRow3", 2, "SecondTableRow2");
    
    firstTable.Merge(joinedTable, false, MissingSchemaAction.Ignore);
    secondTable.Merge(joinedTable, false, MissingSchemaAction.Ignore);
