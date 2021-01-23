    var list = new List<string>() { "A", "B", "C", "D", "E", "F", "G" };
    int groupCount = 3;
    
    var subLists = list.Select((s, i) => new {Str = s, Index = i}).
                        GroupBy(o => o.Index / groupCount, o => o.Str).
                        Select(coll => coll.ToList()).
                        ToList();
