    Container<int> c1 = new Container<int>(10);
    Container<double> c2 = new Container<double>(5.5);
    
    List<Container> list = new List<Container>();
    list.Add(c1);  
    list.Add(c2);  
    
    foreach (Container item in list)
    {  
        Console.WriteLine(item.RawValue);
        Console.WriteLine(item.RawValue); 
    } 
