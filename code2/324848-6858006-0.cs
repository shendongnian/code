    public static IObservable<string> GetRedemeptionNumber()
    {
        var _batchNumber = "test";
                
        var q =
            _context.GetRedemptionsQuery()
            .Where(x => x.ReceiveBatchName.StartsWith(_batchNumber))
            .OrderByDescending(x => x.ReceiveBatchName)
            .Take(1);
    
        return (from u in _context.QuerySingleOrDefault(q)
                from z in u
                select z.Name).Take(1);
    }
