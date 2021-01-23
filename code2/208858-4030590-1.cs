                    MembershipUser membershipUser = Membership.GetUser(user);
                    if (membershipUser != null && membershipUser.IsApproved)
                    {
                        string userRoles = string.Empty;  // Get all their roles
                        FormsAuthenticationUtil.RedirectFromLoginPage(user, userRoles, true); // Create FormsAuthTicket + Cookie + 
                    }
