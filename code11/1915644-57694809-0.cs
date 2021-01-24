public class YourEntity : DbContext
{
    //Configuration stuff for your entity
    ...
    public virtual DbSet<Client> Clients {get;set;}
}
