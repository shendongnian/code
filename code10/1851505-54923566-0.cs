    public static class DbContextExtensions
    {
    /// <summary>
    /// Gets all entities the given entity is relying on.
    /// Will cast the result to a given Type (Entity Base Class / Interface, whatever)
    /// </summary>
    public static List<TEntity> GetAllDependentEntities<TEntity>(this DbContext ctx, TEntity entity)
      where TEntity : class
    {
      return ctx.GetAllRelatedEntities(entity, IsRelationshipParent);
    }
    /// <summary>
    /// Gets all Entities relying on the given entity
    /// Will cast the result to a given Type (Entity Base Class / Interface, whatever)
    /// </summary>
    public static List<TEntity> GetAllEntitiesDependingOn<TEntity>(this DbContext ctx, TEntity entity)
      where TEntity : class
    {
      return ctx.GetAllRelatedEntities(entity, IsRelationshipChild);
    }
    private static List<TEntity> GetAllRelatedEntities<TEntity>(this DbContext ctx, TEntity entity, Func<IRelatedEnd, bool> relationshipFilter)
      where TEntity : class
    {
      var result = new List<TEntity>();
      var queue = new Queue<TEntity>();
      queue.Enqueue(entity);
      while (queue.Any())
      {
        var current = queue.Dequeue();
        var foundDependencies = ctx.GetRelatedEntitiesFrom<TEntity>(current, relationshipFilter);
        foreach (var dependency in foundDependencies)
        {
          if (!result.Contains(dependency))
            queue.Enqueue(dependency);
        }
        result.Add(current);
      }
      return result;
    }
    private static List<TEntity> GetRelatedEntitiesFrom<TEntity>(this DbContext ctx, object entity, Func<IRelatedEnd, bool> relationshipFilter)
      where TEntity : class
    {
      var stateManager = (ctx as IObjectContextAdapter)?.ObjectContext?.ObjectStateManager;
      if (stateManager == null)
        return new List<TEntity>();
      if (!stateManager.TryGetRelationshipManager(entity, out var relationshipManager))
        return new List<TEntity>();
      return relationshipManager.GetAllRelatedEnds()
                                .Where(relationshipFilter)
                                .SelectMany(ExtractValues<TEntity>)
                                .Where(x => x != null)
                                .ToList();
    }
    private static IEnumerable<TEntity> ExtractValues<TEntity>(IRelatedEnd relatedEnd)
      where TEntity : class
    {
      if (!relatedEnd.IsLoaded)
        relatedEnd.Load();
      if (relatedEnd is IEnumerable enumerable)
        return ExtractCollection<TEntity>(enumerable);
      else
        return ExtractSingle<TEntity>(relatedEnd);
    }
    private static IEnumerable<TEntity> ExtractSingle<TEntity>(IRelatedEnd relatedEnd)
      where TEntity : class
    {
      var valueProp = relatedEnd.GetType().GetProperty("Value");
      var value = valueProp?.GetValue(relatedEnd);
      yield return value as TEntity;
    }
    private static IEnumerable<TEntity> ExtractCollection<TEntity>(IEnumerable enumerable)
    {
      return enumerable.OfType<TEntity>();
    }
    private static bool IsRelationshipParent(IRelatedEnd relatedEnd)
      => relatedEnd.SourceRoleName.Contains("Target");
    private static bool IsRelationshipChild(IRelatedEnd relatedEnd)
      => relatedEnd.TargetRoleName.Contains("Target");
    }
