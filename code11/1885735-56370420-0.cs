c#
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
    public IEnumerable<ProjectUser> ProjectClients => this.ProjectUsers
        .Where(x => x.UserType == "Client");
    public IEnumerable<ProjectUser> ProjectBuilders => this.ProjectUsers
        .Where(x => x.UserType == "Builder");
    public IEnumerable<ProjectUser> ProjectDesigners => this.ProjectUsers
        .Where(x => x.UserType == "Designer");
}
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public virtual ICollection<ProjectUser> UserProjects { get; set; }
}
public class ProjectUser
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
    public string UserType { get; set; }
}
###Configurations###
c#
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Ignore(x => x.ProjectBuilders);
        builder.Ignore(x => x.ProjectClients);
        builder.Ignore(x => x.ProjectDesigners);
        builder.ToTable("Project");
    }
}
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.ToTable("User");
    }
}
public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
{
    public void Configure(EntityTypeBuilder<ProjectUser> builder)
    {
        builder.HasKey(x => new { x.ProjectId, x.UserId, x.UserType });
        builder.Property(x => x.UserType).IsRequired();
        builder.HasOne(x => x.Project)
            .WithMany(x => x.ProjectUsers)
            .HasForeignKey(x => x.ProjectId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.UserProjects)
            .HasForeignKey(x => x.UserId);
    }
}
The `virtual` keyword is there for lazy loading support. If you're not doing lazy loading, you don't have to have `virtual` there. Also you have to `[NotMapped]` those 3 calculated properties, which is the same as using `.Ignore` in fluent API's speaking.
###DbContext###
c#
public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectUserConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=DL.SO.ProjectUsersDemo;Integrated Security=True;MultipleActiveResultSets=False;");
    }
}
Nothing special here. After you add the migration and update the database, yours should look like
[![enter image description here][1]][1]
After seeding the database with sample data, although it's hard to show here, you can see those 3 lists are filled with correct data:
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/eQuaO.png
  [2]: https://i.stack.imgur.com/DpA1t.png
