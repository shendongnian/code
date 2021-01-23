    DataTable oldTable = new DataTable();
    DataTable newTable = oldTable.Copy();
    for (int i = 5; i < 65; i++)
    {
        newTable.Columns.RemoveAt(i);   
    }
