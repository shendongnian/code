    List<string> lst = new List<string>{"A1", "A2", "A3" };
    List<string> excludedList = new List<string>{ "A1", "A2" };
    var list = lst.Select(e => e)
                  .Except(excludedList);
    
    foreach (var a in list)
    {
        Console.WriteLine(a + "\n"); //Displays A3
    }
