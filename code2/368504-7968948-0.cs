    IPrincipal credentials = (IPrincipal)HttpContext.Current.User;
    bool isAuthenticated = false;
    if (credentials != null)
    {
        WindowsIdentity identity = (WindowsIdentity)credentials.Identity;
        isAuthenticated = identity.IsAuthenticated;
    }
    if (isAuthenticated != null)
    { //do what needs to be done }
