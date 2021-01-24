    Dictionary<string, IEnumerable<IHasId>> A = new Dictionary<string, IEnumerable<IHasId>>();
    A.Add("111", new List<IHasId> { new AAA { Id = 1 }, new AAA { Id = 2 } });
    A.Add("333", new List<IHasId> { new AAA { Id = 3 } });
    Dictionary<string, IEnumerable<IHasId>> B = new Dictionary<string, IEnumerable<IHasId>>();
    B.Add("111", new List<IHasId> { new AAA { Id = 1 }});
    B.Add("222", new List<IHasId> { new AAA { Id = 2 }});
    B.Add("333", new List<IHasId> { new AAA { Id = 3 } });
    var res = A.Where(a => a.Value.Any(c => B.Any(v => v.Value
               .Select(x => x.Id).Contains(c.Id) && a.Key != v.Key))).ToList();
