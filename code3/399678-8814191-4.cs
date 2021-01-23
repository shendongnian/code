    var list = new List<string>() { "A", "B", "C", "D", "E", "F", "G" };
    int groupCount = 3;
    
    int maxPerGroup = (int)Math.Ceiling((double)list.Count / groupCount);
    
    var subLists = list.Select((s, i) => new {Str = s, Index = i}).
                        GroupBy(o => o.Index / maxPerGroup, o => o.Str).
                        Select(coll => coll.ToList()).
                        ToList();
