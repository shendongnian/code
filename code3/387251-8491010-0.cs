                //Update roles
                foreach (ListItem role in cbRoles.Items)
                {
                    if (role.Selected)
                    {
                        //if user is not in role
                        if (!Roles.IsUserInRole(user.UserName,role.Value))
                        {
                            Roles.AddUserToRole(user.UserName, role.Value);
                        }
                    }//role not selected
                    else
                    {
                        //if user is in a role that is no longer selected remove them
                        if (Roles.IsUserInRole(user.UserName, role.Value))
                        {
                            Roles.RemoveUserFromRole(user.UserName, role.Value);
                        }
                    }
                }
