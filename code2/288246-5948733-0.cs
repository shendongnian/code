    public interface IMyDbSet
    {
        IEnumerable<User> Users { get; }
    }
    
    public class ConcreteDbSet : IMyDbSet
    {
        IEnumerable<User> IMyDbSet.Users {get {return Users;}}
    
        public DbSet<User> Users { get; set; }
    }
