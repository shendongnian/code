    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
           builder.HasData(new Role() {Id=1, Name = "Manager", NormalizedName = "MANAGER",Title="manager" }, new Role() {Id=2, Name = "Student", NormalizedName = "STUDENT",Title="student" });
        }
    }
