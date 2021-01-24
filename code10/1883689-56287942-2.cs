public abstract class File
{
    public int Id { get; set; }
    .....
}
public class Logo : File
{
    ....
}
public class Attachement : File
{
    public Company Company { get; set; }
    public int CompanyId { get; set; }
}
public class Company
{
    public int Id { get; set; }
    public Logo Logo { get; set; }
    public int LogoId { get; set; }
    public ICollection<Attachement> Attachements { get; set; } = new List<Attachement>();
}
public DbSet<Company> Companies { get; set; }
public DbSet<Attachement> Attachements { get; set; }
public DbSet<Logo> Logos { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<File>().HasDiscriminator();
}
