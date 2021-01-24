protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
   modelBuilder.Entity<GenericObject>()
      .HasRequired(genericObject => genericObject.UserWhoGeneratedThisObject)
      .WithOptional(user => user.GenericObject);
}
