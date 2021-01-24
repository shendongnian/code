        protected override void OnModelCreating(ModelBuilder builder)
        {
                base.OnModelCreating(builder);
                builder.Entity<Car>(c =>
                {
                c.ToTable("Car");
                c.HasKey(x => x.Id);
                c.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                c.HasOne(x => x.Owner);
                });
        }
