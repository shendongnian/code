    var genericList = new List<BaseClass>();
    genericList.Add(new Class1());
    genericList.Add(new Class2());
    
    foreach(var item in genericList.OfType<Class1>())
    {
      // no need to cast
      item.IsGreen = true;
    }
