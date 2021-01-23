    public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
    {
        Delegate converter;
        if (!Converters.TryGetValue(typeof(TEntity), out converter))
        {
            throw new InvalidOperationException("...");
        }
        Func<XElement, TEntity> realConverter = (Func<XElement, TEntity>) converter;
        var filename = GetEntityFileName<TEntity>();
        var doc = XDocument.Load(filename);
        return doc.Descendants(entityName)
                  .Select(realConverter)
                  .AsQueryable();
    }
