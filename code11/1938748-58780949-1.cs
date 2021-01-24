    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserRoles Role { get; set; }
    
        public UserProfile Profile { get; set; }
    }
    
    public class ConcreteUser1 : User
    {
        public string ConcreteUser1Prop { get; set; }
    }
    
    public class ConcreteUser2 : User
    {
        public string ConcreteUser2Prop { get; set; }
    }
    public enum UserRoles
    {
        User = 0,
        ConcreteUser1 = 1,
        ConcreteUser2 = 2 
    }
    public enum ProfileRoles
    {
        BaseProfile = 0,
        ConcreteProfile1 = 1,
        ConcreteProfile2 = 2
    }
