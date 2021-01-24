    var dataTable1 = new DataTable();
    dataTable1.Columns.Add(new DataColumn("Data Column 1"));
    dataTable1.Rows.Add(1);
    dataTable1.Rows.Add(3);
    dataTable1.Rows.Add(5);
    dataTable1.Rows.Add(7);
    dataTable1.Rows.Add(9);
    var dataTable2 = new DataTable();
    dataTable2.Columns.Add(new DataColumn("Data Column 1"));
    dataTable2.Columns.Add(new DataColumn("Data Column 2"));
    dataTable2.Columns.Add(new DataColumn("Data Column 3"));
    dataTable2.Rows.Add("", "", 1);
    dataTable2.Rows.Add("", "", 2);
    dataTable2.Rows.Add("", "", 4);
    dataTable2.Rows.Add("", "", 6);
    dataTable2.Rows.Add("", "", 7);
    dataTable2.Rows.Add("", "", 8);
    dataTable2.Rows.Add("", "", 9);
    // Use the id of the column
    var column1 = dataTable1.AsEnumerable().Select(r => r.ItemArray[0]).ToList();
    var column3 = dataTable2.AsEnumerable().Select(r => r.ItemArray[2]).ToList();
    // Use the name of the column
    var column1WithName = dataTable1.AsEnumerable().Select(r => r.Field<string>("Data Column 1")).ToList();
    var column3WithName = dataTable2.AsEnumerable().Select(r => r.Field<string>("Data Column 3")).ToList();
    
    // All element of the Column 1 (DataTable1) that are not in Column 3 (DataTable2)
    var column1Without3 = column1.Except(column3).ToList();
    // All element of the Column 3 (DataTable2) that are not in Column 1 (DataTable1)
    var column3Without1 = column3.Except(column1).ToList();
