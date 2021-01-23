    [WebMethod]
    public bool Login( string username, string password)
    {
        bool isValid = Membership.ValidateUser(username, password);
        if (isValid)
        {
            FormsAuthentication.SetAuthCookie(username, true);
            return true;
        }
        return false;
    }
