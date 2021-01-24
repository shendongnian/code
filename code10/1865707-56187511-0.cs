        private void SetModifierMetadataProperties(EntityEntry<BaseEntity> entry, DateTime saveDate)
        {
            var entity = entry.Entity;
            var currentUserId = GetCurrentUser(entry).Id;
            if (entity.IsDeleted)
            {
                entity.DeletedById = currentUserId;
                entity.DeletedOnUtc = saveDate;
                return;
            }
            if (entry.State == EntityState.Added)
            {
                entity.CreatedById = currentUserId;
                entity.CreatedOnUtc = saveDate;
            }
            entity.ModifiedById = currentUserId;
            entity.ModifiedOnUtc = saveDate;
        }
