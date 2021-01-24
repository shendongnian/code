public enum AuditEventType 
{
    LoggedIn,
    LoggedOut,
    ViewedPage,
    Etc
}
Create an action filter class:
public class AuditEvent : ActionFilterAttribute 
{
    AuditEventType Type;
    public AuditEvent(AuditEventType type) 
    {
        Type = type;
    }
    public override OnActionExecuted() 
    {
         //log user name and audit event to db
    }
}
Decorate your controller method you want to log:
[HttpPost]
[AuditEvent(AuditEventType.LoggedIn)]
public ActionResult Login(LoginModel model) 
{
   //do login logic
}
