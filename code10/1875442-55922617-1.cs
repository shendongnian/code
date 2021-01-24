    using (var ctx = new MyDataContext())
    {
        ctx.Database.Log = Console.WriteLine;
        var results = ctx.SomeTable.Where(<some predicate here>);
        foreach (var row in results)
        {
            //Do something with row here
        }
    }
