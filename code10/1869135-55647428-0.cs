    public class Team
    {
        public Team()
        {
            Users = new List<User>();
        }
        //properties we don't care about
        
        public virtual ICollection<User> Users {get;set;}
    }
    
    public class User
    {
        public User()
        {
            Teams = new List<User>();
        }
        //properties we don't care about
    
        public virtual ICollection<Team> Teams {get;set;}
    }
