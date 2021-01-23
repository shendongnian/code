    private List<User> ParseUsers(Message message)
    {
        return Enumerable
            .Range(0, message.Count)
            .Select(i => message[i])
            .Skip(message.IndexOfFirst(Keys.Name))
            .GroupAdjacent((xs, x) => x.Key == Keys.Phone
                                   || x.Key == Keys.Fax
                                   || x.Key == Keys.Address)
            .Select(g => g.ToDictionary(x => x.Key, x => x.Val))
            .Select(d => new User(d[Keys.Name])
            {
                Phone   = d.ContainsKey(Keys.Phone)   ? d[Keys.Phone]   : null,
                Fax     = d.ContainsKey(Keys.Fax)     ? d[Keys.Fax]     : null,
                Address = d.ContainsKey(Keys.Address) ? d[Keys.Address] : null,
            })
            .ToList();
    }
