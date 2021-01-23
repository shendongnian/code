    public class UserContextTask:BootstrapperTask{
     private readonly IUserSession _userSession;
     public UserContextTask(IUserSession userSession){
       Guard.AgainstNull(userSession);
       _userSession=userSession;
     }
     public override TaskContinuation Execute(){
       UserContext.Initialize(()=>_userSession.GetCurrentUser());
       return TaskContinuation.Continue;
     }
    }
