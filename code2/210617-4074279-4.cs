    public interface IAccountRepository 
    { 
       User GetUserByAccountName(string accountName);
       List<User> GetUsers(Group group); 
       List<Group> GetGroups(User user); 
       // ... etc...
    } 
