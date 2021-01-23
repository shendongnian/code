    public static string GetCurrentUserName()
    {
        if (HostingEnvironment.IsHosted)
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                return current.User.Identity.Name;
            }
        }
        IPrincipal currentPrincipal = Thread.CurrentPrincipal;
        if ((currentPrincipal != null) && (currentPrincipal.Identity != null))
        {
            return currentPrincipal.Identity.Name;
        }
        return string.Empty;
    }
 
 
    
     
 
