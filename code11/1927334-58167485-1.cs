        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            AttachEntity(entity);
            Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        private void AttachEntity(TEntity entity)
        {
            var local = Entities.Local.FirstOrDefault(c => c.Id == entity.Id);
            if (local != null)
            {
                DbContext.Entry(local).State = EntityState.Detached;
            }
            Entities.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
