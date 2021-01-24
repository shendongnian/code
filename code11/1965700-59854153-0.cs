    public class ApplicationUser:IdentityUser<string>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
