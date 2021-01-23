    public AspNetHostingPermissionLevel GetCurrentTrustLevel()
    {
        foreach (AspNetHostingPermissionLevel trustLevel in Enum.GetValues(typeof(AspNetHostingPermissionLevel)))
        {
            try
            {
                new AspNetHostingPermission(trustLevel).Demand();
            }
            catch (System.Security.SecurityException)
            {
                continue;
            }
            return trustLevel;
        }
        return AspNetHostingPermissionLevel.None;
    } 
