     public static void ReloadEntity<TEntity>(this DbContext context,                    TEntity entity)
                 where TEntity : class
          {
             ((IObjectContextAdapter)context)
               .ObjectContext
               .Refresh(RefreshMode.StoreWins, entity);
          }
