        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .ForFirebirdUseIdentityColumns()
                .ForSqlServerUseIdentityColumns();
            modelBuilder.Entity<TblTest>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tblTest");
                entity.Property(e => e.Name).IsUnicode(false);
            });
        }
