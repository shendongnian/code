    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<AppUserRole> AppUserRole { get; set; }
    }
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public List<AppUserRole> AppUserRole { get; set; }
    }
    public class AppUserRole
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
