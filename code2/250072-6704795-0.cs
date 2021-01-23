    object someType = new SomeTypes { Name = "TestName", Age = 23 }
    
    var result = Mapper.DynamicMap<Result>(someType);
    
     
