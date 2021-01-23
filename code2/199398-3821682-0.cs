    "AAAA,12,BBBB,34,CCCC,56".Split(',').Aggregate(
        new { Uneven = new List<string>(), Even = new List<string>() },
        (seed, s) => { 
            if (seed.Uneven.Count > seed.Even.Count) 
                seed.Even.Add(s);
            else
                seed.Uneven.Add(s);
            return seed;
        });
