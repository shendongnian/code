        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var table1Entity = modelBuilder.Entity<Table1>();
            table1Entity.ToTable(nameof(Table1));
            table1Entity.HasKey(i => i.Id);
            table1Entity.Property(i => i.Id).UseSqlServerIdentityColumn();
            var view1Query = modelBuilder.Query<View1>(); // we assume this view already exists in the DB
            view1Query.ToView(nameof(View1));
            view1Query.HasOne(i => i.Table1).WithMany().HasForeignKey(i => i.Table1Id);
        }
