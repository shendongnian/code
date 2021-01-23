    Container<int> c1 = new Container<int>(10);
    Container<double> c2 = new Container<double>(5.5);
    List<IContainer> list = new List<IContainer>();
    list.Add(c1);
    list.Add(c2);
            
    foreach (IContainer item in list)
    {
        Console.WriteLine(item.GetValue());
    }
