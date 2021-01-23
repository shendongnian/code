    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false )]
    public class IsUserAdminAttribute : CustomAuthorizedBaseAttribute
    {
        // Custom logic to redirect to admin logon partial/view
        ...
    }
    
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false )]
    public class IsAuthenticatedAttribute : CustomAuthorizedBaseAttribute
    {
        // Custom logic to redirect to basic/comment logon partial/view
        ...
    }
    
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false )]
    public abstract class CustomAuthorizedBaseAttribute : AuthorizeAttirbute
    {
        // Shared custom logic implementation
        ...
    }
