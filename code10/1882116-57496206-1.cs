    public IActionResult GetData(ODataQueryOptions<YourType> query)
    {
        var data = _context.SetOfYourType;
        return Ok(new
        {
            Items = query.ApplyTo(data),
            Count = query.Count?.GetEntityCount(query.Filter?.ApplyTo(data, new ODataQuerySettings()) ?? data)
        });
    }
