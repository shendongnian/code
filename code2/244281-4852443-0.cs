        var py = Python.CreateEngine();
        // 1
        var value = py.Execute("1+1");
        Console.WriteLine(value);
        // 2
        var scriptScope = py.CreateScope();
        py.Execute("a = 1 + 1", scriptScope);
        var value2 = scriptScope.GetVariable("a");
        Console.WriteLine(value2);
