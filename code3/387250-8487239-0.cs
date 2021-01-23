            string[] existingRoles = Roles.GetRolesForUser(userName);
            foreach (string role in existingRoles)
            {
                if (!newRoles.Contains(role))
                {
                    Authentication.AuthTraceStatic("Removing user {0} from role: {1}", userName, role);
                    lock(o)
                    {
                         if(Roles.IsUserInRole(userName, role))
                              Roles.RemoveUserFromRole(userName, role);
                         else
                             Authentication.AuthTraceStatic("Somebody is messing with my roles!!", userName, role);
                    }
                }
            }
