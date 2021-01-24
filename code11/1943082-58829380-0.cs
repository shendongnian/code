protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<TeamMember>()
        .HasOne(b => b.User)
        .WithOne(TeamMember)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
}
