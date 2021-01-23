        protected void Session_Start(Object sender, EventArgs e)
        {
            SessionStateSection sessionState = 
     (SessionStateSection)ConfigurationManager.GetSection("system.web/sessionState");
            string sidCookieName = sessionState.CookieName;
            if (Request.Cookies[sidCookieName] != null)
            {
                HttpCookie sidCookie = Response.Cookies[sidCookieName];
                sidCookie.Value = Session.SessionID;
                sidCookie.HttpOnly = true;
                sidCookie.Secure = true;
                sidCookie.Path = "/";
            }
        }
