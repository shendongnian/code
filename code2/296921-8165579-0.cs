    public static TEntity Find<TEntity>(this ObjectSet<TEntity> set, object id) where TEntity : EntityObject
        {
          using (var context = new MyObjectContext())
          {
            var entity = set.Context.CreateObjectSet<TEntity>();
            string keyName = entity.FirstOrDefault().EntityKey.EntityKeyValues.FirstOrDefault().Key;
    
            return entity.Where("it." + keyName + " = " + id).FirstOrDefault();
          }
        }
