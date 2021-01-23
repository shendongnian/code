    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
             this.HasKey(t => t.Id);
             this.HasOptional(u => u.CreatedBy);
             // Map the 'DateCreated' Property to the 'CreatedById' table field.
             this.Property(u => u.DateCreated).HasColumnName("CreatedById");
             this.Property(u => u.Name).HasMaxLength(64);
             this.Property(u => u.Username).HasMaxLength(64);
         }
     }
