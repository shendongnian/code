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
