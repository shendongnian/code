    public EFDbContext(HttpContext context) {
        _context = context;
    }
    public HttpContext _context {
        get;
        private set;
    }
    
    public override int SaveChanges() {
        DateTime currentDateTime = DateTime.Now;
        foreach (var auditableEntity in ChangeTracker.Entries<IAuditableEntity>()) {
            if (auditableEntity.State == EntityState.Added || auditableEntity.State == EntityState.Modified) {
                auditableEntity.Entity.LastModifiedDate = currentDateTime;
                switch (auditableEntity.State) {
                        case EntityState.Added:
                            auditableEntity.Entity.CreatedDate = currentDateTime;
                            auditableEntity.Entity.CreatedBy = _context.User.Identity.Name;
                            break;
                        case EntityState.Modified:
                            auditableEntity.Entity.LastModifiedDate = currentDateTime;
                            auditableEntity.Entity.LastModifiedBy = _context.User.Identity.Name;
                            if (auditableEntity.Property(p => p.CreatedDate).IsModified || auditableEntity.Property(p => p.CreatedBy).IsModified) {
                                throw new DbEntityValidationException(string.Format("Attempt to change created audit trails on a modified {0}", auditableEntity.Entity.GetType().FullName));
                            }
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
