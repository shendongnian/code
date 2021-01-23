    public class UserFactory
    {
     public static List<User> GetUsers()
     {
     }
    
     //Optional method to get users in group from user factory
     public static List<User> GetUsersInGroup(int GroupID)
     {
      return UserGroupFactory.GetUsersInGroup(int GroupID)
     }
    }
    
    public class UserGroupFactory
    {
     public static List<UserGroup> GetUserGroups()
     {
     }
    
     public static List<User> GetUsersInGroup(int GroupID)
     {
     }
    }
