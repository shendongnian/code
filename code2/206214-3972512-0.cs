    var names = GetAllDirectoryNames();
    names.Sort(CompareNames);
    foreach( var name in Names)
    {
      DoSomethingWithDir(name);
    }
    
    //...
    
    private static int CompareNames(string x, string y)
    {
      //decide if x should come before y here  see List<T>.Sort(Comparison<T>)
    }
