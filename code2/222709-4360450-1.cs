    public class Context : DbContext {
        //your models
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<SomeTable>()
                             .MapSingleType()
                             .ToTable("YourTableNameInDatabase");
        }
    }
