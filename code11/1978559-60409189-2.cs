c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasMany(a => a.TicketsFromMe)
        .WithOne(a => a.UserFrom)
        .HasForeignKey(a => a.UserFromId).OnDelete(DeleteBehavior.Restrict); 
    modelBuilder.Entity<User>()
        .HasMany(a => a.TicketsToMe)
        .WithOne(a => a.UserTo)
        .HasForeignKey(a => a.UserToId).OnDelete(DeleteBehavior.Restrict); 
}
