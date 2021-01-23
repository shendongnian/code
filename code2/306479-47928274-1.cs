        private class _navPropInhibitingContext : EF.ApplicationDBContext
        {
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<MyEntity>()
                    .Ignore(e => e.Path);
            }
        }
