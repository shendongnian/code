 [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizationForAction : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
              //your custom logic to authorize your action
        }
}
and use AuthorizationForAction tag over your specific action on controller
