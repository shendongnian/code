    public class Accounts
    { 
       IAccountRepository _repository; 
    
       public Accounts(IAccountRepository repository) 
       { 
          _repository = repository; 
       } 
    
       public List<User> GetUsers(Group group) 
       { 
          return _repository.GetUsers(group); 
       } 
    
       public List<Group> GetGroups(User user) 
       { 
          return _repository.GetGroups(user); 
       } 
       public User GetUserByAccountName(string accountName)
       {
           return _repository.GetUserByAccountName(accountName); 
       }
 
    
       // etc...
    } 
