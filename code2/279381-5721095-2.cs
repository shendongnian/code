    public class User
    {
        ...
        [InverseProperty("Owner")]
        public virtual ICollection<Group> OwnedGroups { get; set; }
        [InverseProperty("Members")]
        public virtual ICollection<Group> Groups { get; set; }
    }
    public class Group
    {
        ...
        [InverseProperty("OwnedGroups")]
        public virtual User Owner { get; set; }
        [InverseProperty("Groups")]
        public virtual ICollection<User> Members { get; set; }
    }
