    IEnumerable<O> query = context.Obj;
    if (A != null)
    {
        query = query.Where(o => o.A == A);
    }
    var list = query.ToList();
