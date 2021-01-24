    public class User : IdentityUser<int>
    {
        public User() {
             Properties = new List<Property>();
        }
    
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
