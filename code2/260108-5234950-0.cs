    MembershipUserCollection users = Membership.GetAllUsers();
    MembershipUserCollection deletedUsers = new MembershipUserCollection();
        foreach (MembershipUser x in users)
        {
            if (!Roles.IsUserInRole(x.UserName, "CMS-AUTHOR"))
            {
                deletedUsers.Add(x);
            }
         }
    foreach(MembershipUser delete in deletedUsers)
    {
        users.Remove(delete);
    }
