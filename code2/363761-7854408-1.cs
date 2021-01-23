        public class Db : DbContext
        {
          public DbSet<MyClass> MyClasses{ get; set; }
          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
            modelBuilder.Entity<MyClass>().Ignore(x => x.MyProperty);
          }
        }
