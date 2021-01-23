     private void BeginRequest(Object source, EventArgs e)
        {
            if (null == HttpContext.Current || String.IsNullOrEmpty(HttpContext.Current.Request.Headers["Authorization"]))
            {
                HttpContext.Current.Response.StatusCode = (Int32)HttpStatusCode.Unauthorized;
                HttpContext.Current.Response.End();
            }
            HttpContext context = HttpContext.Current;
            Regex matcher = new Regex(WfmConfigurationManager.GetAppSetting("AuthenticationPath"));
            if (!matcher.IsMatch(context.Request.Url.ToString(),0))
            {
                String authHeader = context.Request.Headers["Authorization"];
                IIdentity tokenIdentity = new TokenIdentity(authHeader);
                if (!tokenIdentity.IsAuthenticated)
                {
                    HttpContext.Current.Response.StatusCode = (Int32)HttpStatusCode.Unauthorized;
                    HttpContext.Current.Response.End();
                }
                IPrincipal tokenPrincipal = new TokenPrincipal(tokenIdentity, TokenAuthentication.GetRolesForUser(tokenIdentity));
                HttpContext.Current.User = tokenPrincipal;
            }
        }
