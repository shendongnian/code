       // Add the new Row
       TableRow row = table.AddRow();
       // Insert at index
       table.Rows.Insert(2, row);
       // Or 
       TableRow row = new TableRow();
       table.Rows.Add(row);
