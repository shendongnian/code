    protected void CreateUserIDCookie(string userID, int timeUntilExpires)
    {
        HttpCookie myCookie = new HttpCookie("UserID", userID);
        myCookie.Expires = DateTime.Now.AddMinutes(timeUntilExpires);
        Response.Cookies.Add(myCookie);
    }
