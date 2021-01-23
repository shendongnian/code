    // User.cs
    public class User
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<Group> Groups { get; set; }
    }
------------------------------------------------------
    // Group.cs
    public class Group
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<User> Users { get; set; }
    }
