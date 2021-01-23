    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    
    namespace YourNameSpace
    {
        public class MyDBContext : DbContext
        {
           protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                // Only including my concrete classes here as we're following Table Per Concrete Class (TPC)
                public virtual DbSet<Attendance> Attendances { get; set; }
                public virtual DbSet<Course> Courses { get; set; }
                public virtual DbSet<Location> Locations { get; set; }
                public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
                public virtual DbSet<Purchase> Purchases { get; set; }
                public virtual DbSet<Student> Students { get; set; }
                public virtual DbSet<Teacher> Teachers { get; set; }
                // Process the SQL Annotations
                Database.SetInitializer(new SqlInitializer<MyDBContext>());
                base.OnModelCreating(modelBuilder);
    
                // Change all datetime columns to datetime2
                modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
    
                // Turn off cascading deletes
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            }
        }
    }
