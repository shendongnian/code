    var code = File.ReadAllText("dynamic.cs");
    var strings = Regex.Matches(code, "\"(\\w*)\"").Cast<Match>()
        .Select(m => m.Groups[1].Value);
    var methods = typeof(System.Linq.Enumerable).GetMethods(BindingFlags.Public 
        | BindingFlags.Static).Select(mi => mi.Name);
    
    string.Join(", ", strings.Intersect(methods)).Dump();
