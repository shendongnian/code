    private List<User> ParseUsers(Message message)
    {
        return Enumerable
            .Range(0, message.Count)
            .Select(i => message[i])
            .SkipWhile(x => x.Key != Keys.Name)
            .GroupAdjacent((g, x) => x.Key != Keys.Name)
            .Select(g => g.ToDictionary(x => x.Key, x => x.Val))
            .Select(d => new User(d[Keys.Name])
            {
                Phone   = d.ContainsKey(Keys.Phone)   ? d[Keys.Phone]   : null,
                Fax     = d.ContainsKey(Keys.Fax)     ? d[Keys.Fax]     : null,
                Address = d.ContainsKey(Keys.Address) ? d[Keys.Address] : null,
            })
            .ToList();
    }
