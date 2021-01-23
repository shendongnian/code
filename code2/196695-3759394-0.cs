    var list = new[] { "foo","bar","jar","\r","a","b","c","\r","x","y","z","\r" };
    var res = list.Aggregate(new List<List<string>>(),
                             (l, s) =>
                             {
                                 if (s == "\r")
                                 {
                                     l.Add(new List<string>());
                                 }
                                 else
                                 {
                                     if (!l.Any())
                                     {
                                         l.Add(new List<string>());
                                     }
                                     l.Last().Add(s);
                                 }
                                 return l;
                             });
