    using(var ctx = new MyDatabaseContext())
    {
        var data = ctx
        .MyTable1
        .SelectMany(a => ctx.MyTable2
          .Where(b => b.Id2 == a.Id1)
          .DefaultIfEmpty()
          .Select(b => new
          {
    	    a.Id1,
    	    a.Col1,
    	    Col2 = b == null ? (int?) null : b.Col2,
          }));
    }
