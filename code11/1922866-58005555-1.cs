    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
            builder.Entity<OwnerCow>()
                    .HasOne(oc => oc.Cow)
                    .WithMany(c => c.OwnerCows)
                    .HasForeignKey(oc => oc.CowId);
            builder.Entity<OwnerCow>()
                .HasOne(oc => oc.Owner)
                .WithMany(o => o.OwnerCows)
                .HasForeignKey(oc => oc.OwnerId);
        }
    }
