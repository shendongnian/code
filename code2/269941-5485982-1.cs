    partnership.ForEach(p => 
        { 
            p.Partner.Services = new List<Tuple<int, string>>(); 
            p.Partner.Services.AddAll(from s in services
                     where s.Item3 == p.Partner.Id
                     select Tuple.Create(s.Item1, s.Item2))
        });
