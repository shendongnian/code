    using System.Security.Principal;
    ------------------------
    WindowsImpersonationContext impersonationContext;
    impersonationContext = 
        ((.WindowsIdentity)HttpContext.User.Identity).Impersonate();
    //Call your service here.
    impersonationContext.Undo();
