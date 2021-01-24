    var query = Context.Things;
    if (!all)
    {
       query = query.Where(t => t.DeletedOn == null || _.Deletedon > DateTime.Now)
    }
    var output = await query
       .ToListAsync();
