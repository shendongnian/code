    public static User GetUserById(this IEnumerable<User> users, string id)
    {
         if(users == null)
            throw new ArgumentNullException("users");
    
         // Perfectly fine if documented that a failure in the query
         // is treated as an exceptional circumstance. Caller's job 
         // to guarantee pre-condition.        
         return users.Single(user => user.Id == id);    
    }
