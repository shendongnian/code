    public static class Session{
         public static Dictionary<User, DateTime> loggedInUser;    
         public static Add(User user){
             loggedInUser.Add(user, DateTime.Now);
             // raise event user arrival
         }
    
         public static GetUser(int Id){
             // fetch user;
         }
    
         public static Remove(User user){
            loggedInUser.Removed(user);
            // raise event user left
         }
    
         // TODO: add timer to check itself. If not activity done in past n minutes, 
         //log him out
    }
