        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }
        private void AddTimestamps()
        {
            //var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            //ObjectiveContext context = ((IObjectContextAdapter)this).ObjectContext;
            var entities = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Modified || e.State == EntityState.Added)).ToList();
            var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CREATEDON = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).CREATEDBY = currentUsername;
                }
                ((BaseEntity)entity.Entity).MODIFIEDON = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).MODIFIEDBY = currentUsername;
            }
        }
