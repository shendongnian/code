    Dictionary<string, IEnumerable<IHasId>> A = new Dictionary<string, IEnumerable<IHasId>>();
    A.Add("111", new List<IHasId> { new AAA { Id = 1 }, new AAA { Id = 2 } });
    Dictionary<string, IEnumerable<IHasId>> B = new Dictionary<string, IEnumerable<IHasId>>();
    B.Add("111", new List<IHasId> { new AAA { Id = 1 }});
    B.Add("222", new List<IHasId> { new AAA { Id = 2 }});
    var res = A.SelectMany(a => a.Value.Where(c => B.Any(v => v.Value.Select(x => x.Id).Contains(c.Id) && a.Key != v.Key))).ToList();
