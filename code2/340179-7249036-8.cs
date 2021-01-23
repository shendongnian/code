    public string SerializeQuery<T>(IQueryable<T> query, Func<T, List<string>> select)
    {
        //filtering
        if (IsSearch && Where.rules != null)
        {
            if (Where.groupOp == "AND") // TODO: INSENSITIVE EQUALS, Y un enum GridGroupOperation.And.Name()
            {
                foreach (var rule in Where.rules)
                    query = query.Where(rule.field, rule.data, rule.op);
            }
            else if (Where.groupOp == "OR") // TODO: INSENSITIVE EQUALS, Y un enum GridGroupOperation.Or.Name()
            {
                var temp = (new List<T>()).AsQueryable();
                foreach (var rule in Where.rules)
                {
                    var t = query.Where(rule.field, rule.data, rule.op);
                    temp = temp.Concat(t);
                }
                //remove repeat records
                query = temp.Distinct();
            }
        }
        //sorting
        query = query.OrderBy(SortColumn, SortOrder);
        //count
        var totalCount = query.Count();
        //paging
        var data = query.Skip((PageIndex - 1) * PageSize).Take(PageSize);
        //convert to grid format
        var result = new
        {
            total = (int)Math.Ceiling((double)totalCount / PageSize),
            page = PageIndex,
            records = totalCount,
            rows = data.Select((d, id) => new { id, cell = select(d) }).ToArray()
        };
        return JsonConvert.SerializeObject(result);
    }
