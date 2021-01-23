    public class RepositoryUserAD :  IRepositoryUserAD 
    {
       private readonly PrincipalContext context;
    
       public RepositoryUserAD(PrincipalContext c)
       { 
           context = c;   
       }
    
       public UserPrincipal GetUser(string username)
       {
    
        return UserPrincipal.FindByIdentity(context, username);
    
       }         
    }
