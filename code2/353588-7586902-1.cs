protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //Only access session state if it is available
            if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
            {
                //If we are authenticated AND we dont have a session here.. redirect to login page.
                HttpCookie authenticationCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authenticationCookie != null)
                {
                    FormsAuthenticationTicket authenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);
                    if (!authenticationTicket.Expired)
                    {
                        if (Session[&quot;UniqueUserId&quot;] == null)
                        {
                            //This means for some reason the session expired before the authentication ticket. Force a login.
                            FormsAuthentication.SignOut();
                            Response.Redirect(&quot;Login.aspx&quot;, true);
                            return;
                        }
                    }
                }
            }
        }
