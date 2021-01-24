                if (IsAuthenticated(user, password, LdapCmb))
                {
                    // Connection ok
                    if (AuthenticateGroup(user, password, userLdap, GroupADM))
                    {
                        accessRights = "ADM";
                        // Variable passed to another class (for locking down some contents)
                    }
                    else if (AuthenticateGroup(user, password, userLdap, OtherGroup1))
                    {
                        accessRights = "OTHER1";
                        // Variable passed to another class (for locking down some contents)
                    }
                    else if (AuthenticateGroup(user, password, userLdap, OtherGroup2))
                    {
                        accessRights = "OTHER2";
                        // Variable passed to another class (for locking down some contents)
                    }
                    else
                    {
                        MessageBox.Show(this, "You are not authorized to use this application.", MessageBoxButton.OK, MessageBoxImage.Warning);
                        logIt.AppendText("User " + user + " isn't granted for use");
                        Application.Current.Shutdown();
                    }
                    Close();
                }
                else
                {
                        MessageBox.Show(this, "You are not authorized to use this application.", MessageBoxButton.OK, MessageBoxImage.Warning);
                        logIt.AppendText("User " + user + " isn't granted for use");
                    Close();
                }
