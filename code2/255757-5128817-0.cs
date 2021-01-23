    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>().HasMany(m => m.Friends).WithMany().Map(m =>
            {
                m.MapLeftKey("MemberId");
                m.MapRightKey("FriendId");
                m.ToTable("MembersFriends");
            }
        );
    }
