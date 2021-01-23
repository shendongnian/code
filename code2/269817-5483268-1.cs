    public partial class App_user
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email_address { get; set; }
        public string password { get; set; }
        public int user_type { get; set; }
        public virtual ICollection<User_Role> UserRoles { get; set; }
    }
    public partial class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<User_Role> UserRoles { get; set; }
    }
    public partial class User_role
    {
        [Key, ForeignKey("App_user"), Column(Order = 0)]
        public int user_id { get; set; }
        [Key, ForeignKey("Role"), Column(Order = 1)]
        public int role_id { get; set; }
        public virtual Role Role { get; set; }
        public virtual App_user App_user { get; set; }
    }
