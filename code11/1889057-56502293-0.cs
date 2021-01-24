csharp
modelBuilder.Entity<GroupUsers>().HasKey(gu => new { gu.GroupId, gu.UserId});
modelBuilder.Entity<GroupUsers>().HasOne(ub => ub.Users)
    .WithMany(x => x.GroupUsers).HasForeignKey(h => h.UserId)  // <-- change to this
    .OnDelete(DeleteBehavior.SetNull);
modelBuilder.Entity<GroupUsers>().HasOne(ub => ub.Groups)
    .WithMany(x => x.GroupUsers).HasForeignKey(h => h.GroupId)  // <-- change to this
    .OnDelete(DeleteBehavior.Cascade);
