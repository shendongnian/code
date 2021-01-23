    var code = File.ReadAllText("dynamic.cs");
    var strings = Regex.Matches(code, "\"(\\w*)\"").Cast<Match>()
        .Select(m => m.Groups[1].Value).Distinct();
    var methods = typeof(System.Linq.Enumerable).GetMethods(BindingFlags.Public 
        | BindingFlags.Static).Select(mi => mi.Name).Distinct();
    
    string.Join(", ", strings.Intersect(methods)).Dump();
