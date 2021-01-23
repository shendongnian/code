    foreach (var p in partnership)
        p.Partner.Services = new List<Tuple<int, string>>();
    foreach (var s in services)
    {
        partnership.Where(p => s.Item3 == p.Partner.Id).ToList().ForEach(
            p => p.Partner.Services.Add(new Tuple<int, string>(s.Item1, s.Item2)));
    }
