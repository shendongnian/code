    var childIds = ctx.Set<Child>().Select(s => s.Id);
    
    var query = ctx.Set<Child>()
        .GroupJoin(ctx.Set<Parent>(), o => o.Id, i => i.Id, (o, i) => new {o, i})
        .Where(w => w.i.Any())
        .Select(s => s.o)
        .Include(i => i.Parents)
        .Where(w => !w.Parents.Select(s => s.Id).Intersect(childIds).Any());
