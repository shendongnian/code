    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Bar>();
            modelBuilder.Entity<Foo>()
               .Property(x => x.Bar)
               .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Bar>(v))
               .HasColumnType("json");
        }
