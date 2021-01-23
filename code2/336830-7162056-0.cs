    var results = Phones.GroupBy(p => p.PersonId)
                        .Select(g => new Result()
    {
        Name = Persons.Single(x => x.PersonId == g.Key).Name,
        Numbers = g.Select(x => x.Number).ToList()
    });
