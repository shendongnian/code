    ... (continuation)
    DataTable schemaTable;
    // Retrieve column schema into a DataTable.
    schemaTable = dr.GetSchemaTable();
    // For each field in the table...
    foreach (DataRow myField in schemaTable.Rows)
    {
       // For each property of the field...
       foreach (DataColumn myProperty in schemaTable.Columns)
       {
          // Display the field name and value.
          Console.WriteLine(myProperty.ColumnName + " = " + myField[myProperty].ToString());
       }
       Console.WriteLine();
       // Pause.
       //Console.ReadLine();
    }
