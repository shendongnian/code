    var anagrams = new Dictionary<string, IList<string>>()
    {
    	{"hello", new List<string>(){"hello", "helol", "hlelo"}},
    	{"hi", new List<string>(){"hi"}},
    	{"me", new List<string>(){"me", "em"}}
    };
    
    var a2 = anagrams
    	.Where(x => x.Value.Count > 1)
    	.Select(x => new { Key = x.Key, List = x.Value })
    	.Aggregate(new Dictionary<string, IList<string>>(),
    		(acc, item) => { acc.Add(item.Key, item.List); return acc; });
		
