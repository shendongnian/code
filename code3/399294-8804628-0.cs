        public static HttpCookie AuthCookie(CurrentIdentity identity) {
           //Create the Authticket, store it in Cookie and redirect user back
           FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                              identity.Name, DateTime.Now, DateTime.Now.AddHours(3), true, identity.ToString(), FormsAuthentication.FormsCookiePath);
           string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
           HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
           authCookie.Expires = authTicket.Expiration;
           return authCookie;
        }
