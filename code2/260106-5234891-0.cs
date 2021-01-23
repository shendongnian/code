            MembershipUserCollection listUsersAll = Membership.GetAllUsers();
            MembershipUserCollection listUsersAuthors = Membership.GetAllUsers();
            foreach (MembershipUser x in listUsersAll)
            {
                if (!Roles.IsUserInRole(x.UserName, "CMS-AUTHOR"))
                {
                    listUsersAuthors.Remove(x.UserName);
                }     
            }
