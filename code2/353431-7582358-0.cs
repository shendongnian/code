    var test = new Dictionary<int, List<int>>
    {                
        { 2, new List<int> { 3, 4 }},
        { 3, new List<int> { 2, 4 }},
        { 1, new List<int> { 2, 3, 4 }},
        { 4, new List<int> { 2, 3 }}
    };
    var res = test.Where(n => !test.Any(m => m.Key!=n.Key && n.Value.Intersect(m.Value).Count()==n.Value.Count) );
