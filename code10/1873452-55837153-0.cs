    var entity = Mapper.Map<TEntity>(entityDto);
    Context.Add(entity);
    // Here entity.Id contains auto-generated temporary value
    // Other stuff...
    Context.SaveChanges();
    // Here entity.Id contains actual auto-generated value from the db
