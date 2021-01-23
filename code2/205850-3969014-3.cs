    public class AcceptApplications:IUserRights{
      public bool IsSatisfiedBy(User u){
        return u.IsInAnyRole(Role.JTS,Role.Secretary);
      }
      public void CheckRightsFor(User u){
        if(!IsSatisfiedBy(u)) throw new ApplicationException
          ("User is not authorized to accept applications.");
      }
    }
