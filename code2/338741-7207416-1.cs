    using(TransactionScope scope = new TransactionScope())
    {
      using(MyEntities model = new MyEntities())
      {
        model.Connection.Open();
        MyT thing = new MyT{ Value1 = "bla", Value2 = "bla2", Value3 = "foo" };
        model.MyT.AddObject(thing);
        model.SaveChanges();
    
        thing.Value4 = Service.Call("bar");
    
        // this call shouldn't cause anymore an exception in MSDTC
        model.SaveChanges();
        scope.Complete();
      }
    }
