        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foo>().HasKey(f => f.FooId);
            modelBuilder.Entity<Foo>()
                .Map(m =>
                         {
                             m.Properties(b => new {b.Name});
                             m.ToTable("Foo");
                         })
                .Map(m =>
                         {
                             m.Properties(b => new {b.BarId});
                             m.ToTable("FooBar");
                         });
            modelBuilder.Entity<Foo>().HasRequired(f => f.Bar)
                .WithMany(b => b.Foos)
                .HasForeignKey(f => f.BarId);
            modelBuilder.Entity<Bar>().HasKey(b => b.BarId);
            modelBuilder.Entity<Bar>().ToTable("Bar");
        }
