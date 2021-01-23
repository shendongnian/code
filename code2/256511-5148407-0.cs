    Regex r = new Regex(@"at (?<namespace>.*)\.(?<class>.*)\.(?<method>.*(.*)) in (?<file>.*):line (?<line>\d*)");
    var result = r.Match(@"at Foo.Core.Test.FinalMethod(Doh doh) in C:\Projects\src\Core.Tests\Test.cs:line 21");
    if (result.Success)
    {
        string _namespace = result.Groups["namespace"].Value.ToString();
        string _class = result.Groups["class"].Value.ToString();
        string _method = result.Groups["method"].Value.ToString();
        string _file = result.Groups["file"].Value.ToString();
        string _line = result.Groups["line"].Value.ToString();
        Console.WriteLine("namespace: " + _namespace);
        Console.WriteLine("class: " + _class);
        Console.WriteLine("method: " + _method);
        Console.WriteLine("file: " + _file);
        Console.WriteLine("line: " + _line);
    }
 
