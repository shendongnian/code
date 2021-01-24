       // Add the new Row
       TableRow row = table.AddRow();
       // Or 
       TableRow row = new TableRow();
       table.Rows.Add();
       // Insert at index
       table.Rows.Insert(2, row);
