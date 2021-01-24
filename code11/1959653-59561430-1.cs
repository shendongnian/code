    var query = Context.Things;
    if (!all)
    {
       query = query.Where(t => t.DeletedOn == null || t.Deletedon > DateTime.Now)
    }
    var output = await query
       .ToListAsync();
    return output;
