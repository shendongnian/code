    /// <summary>
    /// Logs in the user
    /// </summary>
    /// <param name="Username">The username</param>
    /// <param name="Password">The password</param>
    /// <returns>true if login successful</returns>
    [WebMethod, ScriptMethod]
    public static bool LoginUser( string Username, string Password )
    {
        try
        {
            StaticStore.CurrentUser = new User( Username, Password );
            //check the login details were correct
            if ( StaticStore.CurrentUser.IsAuthentiacted )
            {
                //change the status to logged in
                StaticStore.CurrentUser.LoginStatus = Objects.Enums.LoginStatus.LoggedIn;
                //Store the user ID in the list of active users
                ( HttpContext.Current.Application[ SessionKeys.ActiveUsers ] as Dictionary<string, int> )[ HttpContext.Current.Session.SessionID ] = StaticStore.CurrentUser.UserID;
                return true;
            }
            else
            {
                return false;
            }
        }
        catch ( Exception ex )
        {
            return false;
        }
    }
