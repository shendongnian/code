    override protected void OnInit(EventArgs e)
    {
        // Initialize the base Page class.
        base.OnInit(e);
        //If the session exists
        if (Context.Session != null)
        {
            // IsNewSession indicates the session has been reset or the user's session has timed out.
            if (Session.IsNewSession)
            {
                // new session, check for a cookie. 
                string cookie = Request.Headers["Cookie"];
                // If there is a cookie does it contain ASP.NET Session ID? 
                if ((null != cookie) &&
                    (cookie.IndexOf("ASP.NET_SessionId") >= 0))
                {
                    // Since it's a new session but an ASP.NET cookie exists, the session has expired. Notify the user.  
                    throw new Exception("Your session has timed out. ");
                }
            }
        }
    }
