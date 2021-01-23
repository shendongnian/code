    public class User
    {
        public virtual int Id { get;protected set; }
        public virtual string Name { get;set; }
        public virtual ICollection<UserResource> UserResources { get; set;}
    }
    
    public class UserResource
    {
        public virtual int Id { get; protected set; }
        public virtual User User { get; set;}
        public virtual Resource Resource { get; set;}
        public virtual string AccessLevel { get; set;}
    }
    
    public class Resource
    {
        public virtual int Id { get;protected set; }
        public virtual string Name { get;set; }
    }
