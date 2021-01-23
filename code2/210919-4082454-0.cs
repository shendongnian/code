    IPrincipal currentUser = GetCurrentUser();
    if (((currentUser != null) && (currentUser is RolePrincipal)) && ((((RolePrincipal) currentUser).ProviderName == Provider.Name) && StringUtil.EqualsIgnoreCase(username, currentUser.Identity.Name)))
    {
        flag = currentUser.IsInRole(roleName);
    }
    else
    {
        flag = Provider.IsUserInRole(username, roleName);
    }
