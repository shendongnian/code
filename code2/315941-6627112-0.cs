    for(int i = 0 ; i < srcTable.Rows.Count ; i++)
    {
        destTable.Rows.Add(srcTable.Rows[i].ItemArray);
    }
    ...
    SqlCommandBuilder sCB = new SqlCommandBuilder(adapter);
    adapter.Update(dataSet);
    
