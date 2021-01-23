        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new IndexInitializer<MyContext>());
            base.OnModelCreating(modelBuilder);
        }
