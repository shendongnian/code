    var list1 = new List<Property>{
        new StringProperty { Name = "string property", Value = "hello" },
        new IntListProperty { Name = "Int list", Value = new List<int>{ 2, 3, 5, 7 } }
    };
    for (int i = 0; i < list1.Count; i++) {
        Property prop = list1[i];
        Console.Write(prop.Name); Console.Write(": "); 
        prop.DoSomething();
    }
