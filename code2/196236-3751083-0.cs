    var keysFromList = new HashSet<string>(MyList);
    var results =
        MyDict.Values
              .SelectMany(x => x)
              .OrderBy(x => {
                                int i = x.Key.LastIndexOf('_');
                                string k = (i < 0) ? x.Key.Trim() 
                                                   : x.Key.Substring(0, i);
                                return keysFromList.Contains(k) ? 0 : 1;
                            })
              .Aggregate(new {
                                 Results = new Dictionary<string, string>(),
                                 Values = new HashSet<string>()
                             },
                         (a, x) => {
                                       if (!a.Results.ContainsKey(x.Key)
                                               && !a.Values.Contains(x.Value))
                                       {
                                           a.Results.Add(x.Key, x.Value);
                                           a.Values.Add(x.Value);
                                       }
                                       return a;
                                   },
                         a => a.Results);
