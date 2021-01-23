    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        base.OnAuthorization(filterContext);
        // Here you get an enum indicating the roles this user is in. The method
        // converts the db information to a Role enum before it is returned.
        // If the user is not authenticated, the flag should not be set, i.e. equal 0.
        Role userRole = GetUserRolesFromDatabase();
        // Bitwise comparison of the two role collections.
        if (Roles & userRole > 0)
        {
            // The user is in at least one of the roles in Roles. Return normally.
            return;
        }
        // If we haven't returned yet, the user doesn't have the required privileges.
        new HttpUnauthorizedResult(); 
    }
