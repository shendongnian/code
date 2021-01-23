       MembershipUserCollection users = Membership.GetAllUsers();
       List<string> usersToRemove = new List<string>();
       foreach (MembershipUser x in users)
       {
            if (!Roles.IsUserInRole(x.UserName, "CMS-AUTHOR"))
                usersToRemove.Add(x.UserName);
       }
       foreach(string userName in usersToRemove)
             users.Remove(userName);
