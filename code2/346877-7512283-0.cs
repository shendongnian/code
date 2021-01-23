    var model = 
      AutoMap.AssemblyOf<AuditedEntity>(new AutomappingConfiguration(databaseName))
       .HideDeletedEntities();
    
    ...
    
    public static class ReflectiveEnumerator
      {
        public static IEnumerable<Type> GetSubTypesOf<T>() where T : class
        {
          return Assembly.GetAssembly(typeof (T)).GetTypes()
            .Where(myType => myType.IsClass && 
              !myType.IsAbstract && 
              myType.IsSubclassOf(typeof (T)));
        }
      }
    
      public static class AutoPersistenceModelExtensions
      {
        public static AutoPersistenceModel HideDeletedEntities(this AutoPersistenceModel model)
        {
          var types = ReflectiveEnumerator.GetSubTypesOf<AuditedEntity>();
    
          foreach (var t in types)
          {
            var mapped = typeof(AutoMapping<>).MakeGenericType(t);
    
            var p = Expression.Parameter(mapped, "m");
            var expression = Expression.Lambda(Expression.GetActionType(mapped),
                                               Expression.Call(p, mapped.GetMethod("Where"),
                                                               Expression.Constant("DeletedById is null")), p);
    
            typeof(AutoPersistenceModel).GetMethod("Override").MakeGenericMethod(t)
              .Invoke(model, new object[] { expression.Compile() });
          }
          return model;
        }
      }
