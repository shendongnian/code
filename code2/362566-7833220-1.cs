    internal static void Save<TEntity, TData>(TData data)
        where TEntity : class, IData
        where TData : class, IData
    {
        using (CFOEntityModelContainer database = new CFOEntityModelContainer())
        {
            ObjectSet<TEntity> set = database.CreateObjectSet<TEntity>();
            // Here you have specific method - can you make it generic?
            // If not it must be another parameter (delegate) passed to Save method
            if (!IsValid(data.Id))  
            {
                // Convert is another specific method which must be generalize
                // This time it can be probably solved by overriding conversion
                // operator on each data implementation
                set.AddObject(Convert(data));
            }
            else
            {
                // Another specific logic - can you make it generic?
                // If not it must be passed as delegate
                TEntity entity = set.First(e => e.Id == data.Id);
                entity.Name = data.Name;
            }
            database.SaveChanges();
        }
    }
