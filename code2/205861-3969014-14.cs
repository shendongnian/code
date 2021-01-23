    public class Root:Entity,IRoot{
      public virtual void Authorize(IUserRights rights){
        UserContext.Current.CheckRightsFor(rights);
      }
    }
