    blder.Entity<UserInfo>()
         .HasOne(i => i.User)
         .WithOne();
    blder.Entity<UserInfo>()
         .HasKey(i => i.UserId);
