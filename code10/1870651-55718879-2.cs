    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<Subscription>(s =>
         {
            s.HasKey(sc => sc.AccountId); // <-- AccountId as primary key
            s.HasOne(sc => sc.Account).WithOne(a => a.CurrentSubscription)
                    .HasForeignKey<Subscription>(sc => sc.AccountId);
         });
    }
