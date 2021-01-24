    List<test> tests = new List<test>();
    var ob1=new test{ obj1 = "obj1" };
    var ob2=new test{ obj1 = "obj2" };
    var ob3=new test{ obj1 = "obj3" };
    var ob4=new test{ obj1 = null };
    tests.Add(ob1);
    tests.Add(ob2);
    tests.Add(ob3);
    tests.Add(ob4);
    
    var result = tests.Select(e => new NewType
    {
         name = e.obj1 != null ? e.obj1.ToString() : null
    });
    
    foreach (var item in result)
    {
        Console.WriteLine(item.name);
    }
