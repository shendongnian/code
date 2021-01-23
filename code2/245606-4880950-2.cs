    List<MyClass> list = new List<MyClass>();
    list.Add(new MyClass { Name = "John" });
    list.Add(new MyClass { Name = "David" });
    list.Add(new MyClass { Name = "Adam" });
    list.Add(new MyClass { Name = "Barry" });
    
    const string desiredProperty = "Name"; // You can pass this in
    var result = list.OrderBy(x => GetPropertyByName(x, desiredProperty));
    foreach (MyClass c in result)
    {
        Console.WriteLine(c.Name);
    }
