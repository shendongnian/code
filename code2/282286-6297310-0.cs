    public abstract class Repository : IQueryableRepository, IWritableRepository
    {
      private readonly DbContext _context;
      private readonly Dictionary<Type, LambdaExpression[]> _includes = new Dictionary<Type, LambdaExpression[]>();
      protected Repository(DbContextBase context)
      {
        _context = context;
        RegisterIncludes(_includes);
      }
      
      protected abstract void RegisterIncludes(Dictionary<Type, LambdaExpression[]> includes);
      protected S GetSingle<S>(Expression<Func<S, bool>> query, bool getChildren = false) where S : class
      {
        IQueryable<S> entities = _context.Set<S>().AsNoTracking();
        if (query != null)
          entities = entities.Where(query);
        entities = ApplyIncludesToQuery<S>(entities, getChildren);
        return entities.FirstOrDefault();
      }
      private IQueryable<S> ApplyIncludesToQuery<S>(IQueryable<S> entities, bool getChildren) where S : class
      {
        Expression<Func<S, object>>[] includes = null;
        if (getChildren && _includes.ContainsKey(typeof(S)))
          includes = (Expression<Func<S, object>>[])_includes[typeof(S)];
        if (includes != null)
          entities = includes.Aggregate(entities, (current, include) => current.Include(include));
        return entities;
      }
    }
