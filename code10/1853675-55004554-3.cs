    using(var ctx = new MyDbContext())
    {
        Table1 tbl1 = ctx.Table1s.FirstOrDefault(x => x.ColumnA == "myvalue");
        Table2 tbl2 = ctx.Table2s.FirstOrDefault(x => x.ColumnA == "myvalue");
        Table3 tbl3 = ctx.Table3s.FirstOrDefault(x => x.ColumnA == "myvalue");
        // Perform null checks and other checks against different columns here
    } 
