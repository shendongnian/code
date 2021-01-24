    var dt1 = new DataTable("a");
    dt1.Columns.Add("ID", typeof(int));
    dt1.Columns.Add("Item1", typeof(int));
    dt1.PrimaryKey = new[] { dt1.Columns[0] };
    var dt2 = new DataTable("a");
    dt2.Columns.Add("ID", typeof(int));
    dt2.Columns.Add("Item2", typeof(int));
    dt2.PrimaryKey = new[] { dt2.Columns[0] };
    
    
    for (int i = 0; i < 10; i++)
    {
    	dt1.Rows.Add(new object[] { i, i });
    	dt2.Rows.Add(new object[] { i, i + 10 });
    }
    dt1.PrimaryKey = new[] { dt1.Columns[0] };
    dt2.PrimaryKey = new[] { dt2.Columns[0] };
    
    dt1.Merge(dt2);
