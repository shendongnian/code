    public IEnumerable<Entity> GetAll(
        Func<IQueryable<Entity>, IQueryable<Entity>> query)
    {
        using (var context = new DbContext())
            return query(context.Set<Entity>).ToList();
    }
    
    // then use like this:
    EntityRepository.GetAll((entities) =>
        {
            var query = entities;
            if (param1 != null) query = query.Where(e => e.field1 == param1);
            if (param2 != null) query = query.Where(e => e.field2 == param2);
            if (param3 != null) query = query.Where(e => e.field3 == param3);
            return query;
        });
