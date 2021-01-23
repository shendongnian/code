    // just setting up a table for the sample
    DataTable table = new DataTable();
    table.Columns.Add("ID", typeof(int));
    for (int i = 1; i <= 100; i++)
    {
        table.Rows.Add(i);
    }
    // grabbing rows 11 through 20 using Linq
    DataTable filtered = table.AsEnumerable().Skip(10).Take(10).CopyToDataTable();
    
