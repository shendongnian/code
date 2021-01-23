    using(var dc = new MyDc(@"isostore:/stuff.sdf"))
    {
        if(!dc.DatabaseExists())
           dc.CreateDatabase();
    
        dc.Data.InsertAllOnSubmit(
           Enumerable.Range(0, 6000).Select( i => new MyData { Data = "Hello World" }));
        dc.SubmitChanges();
    }
