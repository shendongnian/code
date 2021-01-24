    var list1 = new List<Property>{
        new StringProperty { Name = "string property", Value = "hello" },
        new IntListProperty { Name = "Int list", Value = new List<int>() }
    };
    for (int i = 0; i < list1.Count; i++) {
        Property prop = list1[i];
        prop.DoSomething();
    }
