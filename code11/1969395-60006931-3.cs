    var factory = new DataContextFactory();
    using DataContextA a = factory.CreateContextA();
    var value = await a.Get();
    using DataContextB b = factory.CreateContextB();
    var value = await b.Get();
    await a.Delete();
    await b.Delete();
    
