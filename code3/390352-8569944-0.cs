        DataTable table = DataSet1.Tables["Orders"];
        // Presuming the DataTable has a column named Date.
        string expression;
        expression = "Date > #1/1/00#"; // you will need logic to remove your duplicates
        DataRow[] foundRows;
    
        // Use the Select method to find all rows excluding duplicates
        foundRows = table.Select(expression);
    
        // .NET 3.5 onwards
        DataTable filteredDataTable = foundRows.copyToDataTable(); 
