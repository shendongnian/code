    IEnumerable GetAccounts(string filter = null)
    {
        var query = from a in accounts select a;
        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(a => a.Currency.Contains(filter));
        }
        return query;
    }
