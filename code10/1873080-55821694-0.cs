    public class ModeratedConfiguration : IEntityTypeConfiguration<ModeratedUser>
    {
        public void Configure(EntityTypeBuilder<ModeratedUser> builder)
        {
            builder.ToTable("ModeratedUsers", "Mod");
            builder.HasKey(x => x.ModeratedId);
        }
    }
    public class ModeratorsConfiguration : IEntityTypeConfiguration<ModeratorUser>
    {
        public void Configure(EntityTypeBuilder<ModeratorUser> builder)
        {
            builder.ToTable("ModeratorUsers", "Mod");
            builder.HasKey(x => x.ModeratorId);
        }
    }
    public class ModeratorModeratedConfiguration : IEntityTypeConfiguration<ModeratorModerated>
    {
        public void Configure(EntityTypeBuilder<ModeratorModerated> builder)
        {
            builder.ToTable("ModeratorModerated", "Mod");
            builder.HasKey(x => new { x.ModeratedId, x.ModeratorId });
            builder.HasOne(x => x.Moderated)
                .WithMany(x => x.ModeratorModerated)
                .HasForeignKey(x => x.ModeratedId);
            builder.HasOne(x => x.Moderator)
                .WithMany(x => x.ModeratorModerated)
                .HasForeignKey(x => x.ModeratorId);
        }
    }
