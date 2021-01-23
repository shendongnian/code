            // Take all Users
            MembershipUserCollection users = Membership.GetAllUsers();
            // Create an empty collector for only User in Author
            MembershipUserCollection usersAuthors = new MembershipUserCollection();
            foreach (MembershipUser x in users)
            {
                if (Roles.IsUserInRole(x.UserName, "CMS-AUTHOR"))
                {
                    usersAuthors.Add(x);
                }
            }
