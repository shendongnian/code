    public class UserRepository : IUserRepository
    {
        Entities dataContext;
    
        public UserRepository(Entities entities)
        {
           this.dataContext = entities;
        }
        public User GetUser(string username)
        {
            return dataContext.Users.SingleOrDefault(x => x.Username == username);
        }
    
        // ... more CRUD-style methods that are not relevant to this question.
    
        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }
    }
