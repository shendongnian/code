    [WebMethod]
    public bool Login(username, password)
    {
        bool isValid = Membership.ValidateUser(username, password);
        if (isValid)
        {
            FormsAuthentication.SetAuthCookie(username, true);
            return true;
        }
        return false;
    }
