    public string SerializeQuery<T>(IQueryable<T> query, Func<T, List<string>> select)
    {
        // stuff ...
        var result = new
        {
            total = (int)Math.Ceiling((double)totalCount / PageSize),
            page = PageIndex,
            records = totalCount,
            rows = data.Select((d, id) => new { id, cell = select(d) }).ToArray()
        };
        // stuff ...
    }
