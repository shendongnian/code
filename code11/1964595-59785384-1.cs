    //Displaying as a table.
    for (int i = 0; i < dt2.Columns.Count; i++)
    {
    	Console.Write(dt2.Columns[i].ColumnName + " \t |");
    }
    Console.WriteLine();
    for (int j = 0; j < dt2.Rows.Count; j++)
    {
    	for (int i = 0; i < dt2.Columns.Count; i++)
    	{
    		Console.Write(dt2.Rows[j].ItemArray[i] + " \t | ");
    	}
    	Console.WriteLine();
    } 
