    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Metadata.RemoveIndex(new[] { builder.Property(r => r.NormalizedName).Metadata });
            builder.HasIndex(r => new { r.NormalizedName, r.ApplicationId }).HasName("RoleNameIndex").IsUnique();
        }
    }
