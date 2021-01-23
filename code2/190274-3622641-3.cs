    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
    }
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        // etc...
    }
    public class UserMapping : EntityConfiguration<User>
    {
        public UserMapping()
        {
            this.HasKey(u => u.Id);
            this.Property(u => u.Username).HasMaxLength(32);
            // User has ONE profile.
            this.HasRequired(u => u.Profile);
        }
    }
    public class ProfileMapping : EntityConfiguration<Profile>
    {
        public ProfileMapping()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.FirstName).HasMaxLength(32);
            this.Property(p => p.LastName).HasMaxLength(32);
            this.Property(p => p.PostalCode).HasMaxLength(6);
        }
    }
