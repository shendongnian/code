    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    Dictionary<string, string> target = new Dictionary<string, string>();
    List<string> source = new List<string>();
    target.Add("a", "this is a");
    target.Add("b", "this is b");
    source.Add("a");
    source.Add("c");
    target = Enumerable.Select(target, n => n.Key).
        Where(n => source.Contains(n)).ToDictionary(n => n, k => target[k]);
