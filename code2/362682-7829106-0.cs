    [mono] /tmp @ csharp
    Mono C# Shell, type "help;" for help
    
    Enter statements below.
    csharp> using System.Linq; using System.Dynamic;                
    csharp> dynamic x = new ExpandoObject();                  
    csharp> x.Data ="test";                                          
    csharp> x.Arr = new [] { "test1","test2"};                  
    csharp> x.Lst = new List<string> { "aap", "noot", "mies" };                  
    csharp> x;
    { [Data, test], [Arr, System.String[]], [Lst, System.Collections.Generic.List`1[System.String]] }
