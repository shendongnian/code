    // starting by cloning 'table' (see code above)
    DataTable filtered = table.Clone();
    int skipRows = 10;
    int selectRows = 10;
    for (int index = skipRows; 
         index < skipRows + selectRows && index < table.Rows.Count; 
         index++)
    {
        filtered.Rows.Add(table.Rows[index].ItemArray);
    }
