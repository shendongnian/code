    public partial class App_user
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email_address { get; set; }
        public string password { get; set; }
        public int user_type { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
    public partial class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
