    public class Example
    {
    
      // Will enforce that the user have the administrator role
      [PrincipalPermission(XXXX, Role="Administrator")]
      public void Remove(int userId)
      {
      }
    
      public void Add(int userId)
      {
         if (!Thread.CurrentPrincipal.IsInRole("User"))
            throw new UnauthorizedAccessException("Only registered users may add users");
      }
      
    }
