    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string Description { get; set; }
    }
