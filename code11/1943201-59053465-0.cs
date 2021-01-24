    public object GetRelatedObject(Guid relationId)
    {
        var relationType = context
                           .DbSet<ComRelation>
                           .Join(context.DbSet<ComType>, r => r.TYPE_ID, t => t.TYPE_ID, (r, t) => new { Relation = r, Type = t })
                           .Where(r => r.ID = relationId)
                           .FirstOrDefault();
    
        Type objectType = Type.GetType(relationType.Type.TARGET_CLASS, "Namespace"), 
             contextType = context.GetType();
    
        var method = contextType.GetMethods()
                     .Where(m => m.Name == "GetObject" && m.IsGenericMethodDefinition)
                     .FirstOrDefault()
                     .MakeGenericMethod(objectType);
    
        return method.Invoke(contextType, new object[] { relationType.Relation.FOREIGN_KEY });
    }
