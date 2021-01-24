[ForeignKey("PM")]
public User PmUser { get; set; }
[ForeignKey("PQL")]
public User PqlUser { get; set; }
...using the User Entity for both fields (Using a Foreign Key - Equal to the field on the main table)...
so, the PM match with idUser... and PQL match with idUser
Now... I have a circular reference when I tried to update the database using Code-first...
So, in the class ```public class ApplicationDbContext : DbContext``` I override the foreign keys:
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<ProjectHeader>().HasOne(m => m.PmUser).WithMany().OnDelete(DeleteBehavior.ClientSetNull);
    modelBuilder.Entity<ProjectHeader>().HasOne(m => m.PqlUser).WithMany().OnDelete(DeleteBehavior.ClientSetNull);
}
