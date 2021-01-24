        private void SetProps<TEntity>(TEntity dbEntity, EntityState newState) where TEntity : class, new()
        {
            var entry = Entry(dbEntity);
            if (dbEntity is IDbEntityBase dbEntityBase)
            {
                if (newState == EntityState.Added)
                {
                    dbEntityBase.Id = Guid.NewGuid();
                }
            }
        }
