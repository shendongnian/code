    class  MyColumns
    {
      public string Column1 {get;set;}
      public string Column2 {get;set;}
    }
    
    ...
    
    using(var context = new FooEntities())
    {
       var results = context.ExecuteStoreQuery<MyColumns>("select Column1, Column2 from MTable");
    }
