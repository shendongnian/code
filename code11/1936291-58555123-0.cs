csharp
public class MyRole: IdentityRole<int>
{
    [Column("RoleId")]
    public override int Id { get; set; }
    [Column("RoleName")]
    public override string Name { get; set; }
}
To reuse the old table, custom the `OnModelCreating(builder)` method:
public class AppIdentityDbContext : IdentityDbContext<MyUser, MyRole, int>
{
    ...
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<MyRole>(e =>{
            e.ToTable("MyRole");
        });
    }
}
