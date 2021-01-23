    System.Web.Security.MembershipUserCollection users = System.Web.Security.Membership.GetAllUsers();
    grid.DataSource = users.OfType<MembershipUser>().OrderBy(GetUserFullName, StringComparer.OrdinalIgnoreCase);
    
    private static string GetUserFullName(MembershipUser user)
    {
        // return here user's full name
        return user.Email;
    }
