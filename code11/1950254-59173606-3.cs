    public class ApplicationDbContextAuditDecorator : IMyDbContext
    {
        private readonly IMyDbContext context;
        private readonly ICurrentUser currentUser;
        public ApplicationDbContextAuditDecorator(IMyDbContext context, ICurrentUser currentUser)
        {
            this.context = context;
            this.currentUser = currentUser;
        }
        public DbSet<Staff> Staff { get => this.context.Staff; }
        public DbChangeTracker ChangeTracker => this.context.ChangeTracker;
        public int SaveChanges()
        {
            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IAuditableEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedBy = this.currentUser.Name();
                            break;
                    }
                }
            }
            return this.context.SaveChanges();
        }
    }
