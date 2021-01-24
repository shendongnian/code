    public async Task<TEntity> UpdateAsync<TEntity, TId>(TEntity entity, bool save = true, params Expression<Func<TEntity, object>>[] navigations)
                where TEntity : class, IIdEntity<TId>
            {
                TEntity dbEntity = await _context.FindAsync<TEntity>(entity.Id);
            EntityEntry<TEntity> dbEntry = _context.Entry(dbEntity);
            dbEntry.CurrentValues.SetValues(entity);
            foreach (Expression<Func<TEntity, object>> property in navigations)
            {
                var propertyName = property.GetPropertyAccess().Name;
                CollectionEntry dbItemsEntry = dbEntry.Collection(propertyName);
                IClrCollectionAccessor accessor = dbItemsEntry.Metadata.GetCollectionAccessor();
                await dbItemsEntry.LoadAsync();
                var dbItemsMap = ((IEnumerable<object>)dbItemsEntry.CurrentValue)
                    .ToDictionary(e => string.Join('|', _context.FindPrimaryKeyValues(e)));
                foreach (var item in (IEnumerable)accessor.GetOrCreate(entity))
                {
                    if (!dbItemsMap.TryGetValue(string.Join('|', _context.FindPrimaryKeyValues(item)), out object oldItem))
                    {
                        accessor.Add(dbEntity, item);
                    }
                    else
                    {
                        _context.Entry(oldItem).CurrentValues.SetValues(item);
                        dbItemsMap.Remove(string.Join('|', _context.FindPrimaryKeyValues(item)));
                    }
                }
                foreach (var oldItem in dbItemsMap.Values)
                {
                    accessor.Remove(dbEntity, oldItem);
                    await DeleteAsync(oldItem as IEntity, false);
                }
            }
            if (save)
            {
                await SaveChangesAsync();
            }
            return entity;
        }
