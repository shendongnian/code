    UserAuth auth;
    [WebMethod]
    public static void PostComment(string comment)
    {
        auth = new UserAuth();
        if (auth.isAuthenticated)
            {
                //Post comment here...
            }
    }
