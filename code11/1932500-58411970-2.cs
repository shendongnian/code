    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // one-to-many relation between Image and UserExtendedInfo:
        modelBuilder.Entity<Image>()
                    .HasMany(image => image.UserExtendedInfos)
                    .WithRequired(userExtendedInfo => userExtendedInfo.Avatar)
                    .HasForeignKey(userExtendedInfo => userExtendedInfo.AvatarId);
