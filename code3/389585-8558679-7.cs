    var results = q
        .JoinAlias(p => p.Identity, () => identityAlias)
        .SelectList(list => list
            .Select(p => p.Id)
            .Select(p => p.FirstName)
            .Select(p => p.LastName)
            .Select(p => identityAlias.Sex)
            .Select(p => identityAlias.BirthDate)
        .List<object[]>()
        .Select(values => new Person((int)values[0])
        {            
            FirstName = (string)values[1],
            LastName = (string)values[2],
            Identity = new Identity()
            {
                Sex = (string)values[3],
                BirthDate = (DateTime)values[4],
            }
        })
        .ToList<Person>();
