    IEnumerable<Reward> result =
        from r in list1.Concat(list2)
        group r by r.User into groupedRewards
        select new Reward
        {
            Game = 0,   //what game to use?
            User = groupedRewards.Key,
            Money = groupedRewards.Sum(r => r.Money)
        };
