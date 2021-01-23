    // Create the data table
    var dataTable = new DataTable("TableName");
    // Add the columns you will need
    dataTable.Columns.Add("FirstName");
    dataTable.Columns.Add("LastName");
    dataTable.Columns.Add("Whatever");
    // Get your data in string array format
    // Will need to be FirstName, LastName, Whatever
    string[] data = LoadStringArrayFromCsvOrSomething();
    // Add the DataRow using the string array
    dataTable.Rows.Add(data);
