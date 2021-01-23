        if (Request.IsAuthenticated == true) {
                // Extract the forms authentication cookie
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = Context.Request.Cookies[cookieName];
                if (null == authCookie) {
                    // There is no authentication cookie.
                    return;
                }
                FormsAuthenticationTicket authTicket = null;
                try {
                    authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                } catch (Exception) {
                    // Log exception details (omitted for simplicity)
                    return;
                }
                if (null == authTicket) {
                    // Cookie failed to decrypt.
                    return;
                }
                // When the ticket was created, the UserData property was assigned a
                // pipe delimited string of role names.
                string[] userInfo = authTicket.UserData.Split('|');
                // Create an Identity object
                FormsIdentity id = new FormsIdentity(authTicket);
                //Populate CurrentIdentity, from Serialized string
                CurrentIdentity currentIdentity = new CurrentIdentity(userInfo[0], userInfo[1], userInfo[2]);
                System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(currentIdentity, userInfo);
                Context.User = principal;
        }
