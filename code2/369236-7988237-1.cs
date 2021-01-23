    IEnumerable<Reward> result = list1.Concat(list2)
        .GroupBy(u => u.User)
        .Select(g => new Reward
        {
            Game = 0,  //what game to use?
            User = g.Key,
            Money = g.Sum(r => r.Money)
        });
