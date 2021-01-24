    public class UserProfile 
    {
        public Guid Id { get; set; }
    
        public ProfileRoles Role { get; set;}
        public string SameProp { get; set; }
    
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
    
    public class ConcreteUser1Profile : UserProfile
    {
        public string ConcreteProfile1Prop { get; set; }
    }
    
    public class ConcreteUser2Profile : UserProfile
    {
        public string ConcreteProfile2Prop { get; set; }
    }
