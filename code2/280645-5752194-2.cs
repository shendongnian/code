    DataTable filtered = table.Clone();
    int startingRow = 10;
    int selectRows = 10;
    for (int index = startingRow; 
         index < startingRow + selectRows && index < table.Rows.Count; 
         index++)
    {
        filtered.Rows.Add(table.Rows[index].ItemArray);
    }
