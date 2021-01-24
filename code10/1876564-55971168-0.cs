    public void ApplyMigrations(ApplicationDbContext context) {
        if (context.Database.GetPendingMigrations().Any()) {
            context.Database.Migrate();
        }
    }
