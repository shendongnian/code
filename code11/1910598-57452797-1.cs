    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>().HasOne<Student>(n => n.Student)
                .WithMany(s => s.Notes)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Notes>().ToTable("Notes");
            base.OnModelCreating(modelBuilder);
        }
