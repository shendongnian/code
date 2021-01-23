    using (var context = new PrincipalContext(ContextType.Machine, "MachineName", "AdminUserName", "AdminPassword"))
    {
        UserPrincipal user = new UserPrincipal(context, username, password, true);
        user.Description = "Test User from .NET";
        user.Save();
        var guestGroup = GroupPrincipal.FindByIdentity(context, "Guests");
        if (guestGroup != null)
        {
            guestGroup.Members.Add(user);
            guestGroup.Save();
        }
    }
