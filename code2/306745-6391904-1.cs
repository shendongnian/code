       public static TEntity CopyTo<TEntity>(this TEntity OriginalEntity, TEntity NewEntity)
        {
            PropertyInfo[] oProperties = OriginalEntity.GetType().GetProperties();
            foreach (PropertyInfo CurrentProperty in oProperties.Where(p => p.CanWrite))
            {
                CurrentProperty.SetValue(OriginalEntity, newEntityValue, null);
            }
            return OriginalEntity;
        }
