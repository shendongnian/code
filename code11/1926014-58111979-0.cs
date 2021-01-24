    public class User
    {
        public long Id { get; set; }
    
        public string Name { get; set; }
    
        public ICollection<UserGroup> UserGroups { get; set; }
    }
    
    public class UserGroup
    {    
    
        public long GroupId{ get; set; }
    
        public string Name { get; set; }
    }
