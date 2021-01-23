        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Admin");
                    
            //Map pk in table
            modelBuilder.Entity<Student>().HasKey(t => t.ID_CERT);
            modelBuilder.Entity<Student>().Property(t => t.ID_CERT)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
