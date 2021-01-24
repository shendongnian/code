c#
public class User
{
    public int Id { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    [InverseProperty("UserTo")]
    public ICollection<Ticket> TicketsToMe { get; set; }
    [InverseProperty("UserFrom")]
    public ICollection<Ticket> TicketsFromMe { get; set; }
}
2 - FluentApi
c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasMany(a => a.TicketsFromMe)
        .WithOne(a => a.UserFrom)
        .HasForeignKey(a => a.UserFromId);
    modelBuilder.Entity<User>()
        .HasMany(a => a.TicketsToMe)
        .WithOne(a => a.UserTo)
        .HasForeignKey(a => a.UserToId);
}
