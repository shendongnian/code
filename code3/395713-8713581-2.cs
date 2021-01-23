    System.Exception test = new Exception();
    var methods = test.GetType().UnderlyingSystemType.GetMethods();
    
    foreach (var t in methods)
    {
    	Console.WriteLine(t.Name);
    }
