     public T Update(T entity)
     {
          if (entity == null) throw new ArgumentNullException("entity");
          var key = ObjectContext.CreateEntityKey(ObjectContext.GetEntitySet<T>().Name, entity);
          if (ObjectContext.IsAttached(key))
          {
              ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
          }
          else
          {
              ObjectContext.AttachTo(ObjectContext.GetEntitySet<T>().Name, entity);
              ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
          }
          return entity;
     }  
 
    internal static EntitySetBase GetEntitySet<TEntity>(this ObjectContext context)
     {
          var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
          var baseType = GetBaseType(typeof(TEntity));
          var entitySet = container.BaseEntitySets
                    .Where(item => item.ElementType.Name.Equals(baseType.Name))
                    .FirstOrDefault();
    
          return entitySet;
     }  
    internal static bool IsAttached(this ObjectContext context, EntityKey key)
     {
          if (key == null)
          {
              throw new ArgumentNullException("key");
                }
              ObjectStateEntry entry;
              if (context.ObjectStateManager.TryGetObjectStateEntry(key, out entry))
              {
                    return (entry.State != EntityState.Detached);
              }
               return false;
     }
  
      private static Type GetBaseType(Type type)
      {
           var baseType = type.BaseType;
           if (baseType != null && baseType != typeof(EntityObject))
           {
                return GetBaseType(type.BaseType);
           }
           return type;
      }
