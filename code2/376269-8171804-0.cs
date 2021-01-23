    var ctx = new DatabaseContext("ScalabilityTestEntities");
    ctx.Configuration.LazyLoadingEnabled = false;
    var a = ctx.As.FirstOrDefault();
    a.Bs = new List<B>();
    a.Bs.Add(new B { SomeValue = 987 });
