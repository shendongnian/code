public abstract class File
    {
        public int Id { get; set; }
}
public abstract class File
{
    public int Id { get; set; }
}
public class Logo : File
{
}
public class Attachement : File
{
    public Company Company { get; set; }
    public int CompanyId { get; set; }
}
public DbSet<Company> Companies { get; set; }
public DbSet<Attachement> Attachements { get; set; }
public DbSet<Logo> Logos { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<File>().HasDiscriminator();
}
