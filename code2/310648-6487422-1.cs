    public HttpCookie AddHttpCookie(String userID, int timeOut)
    {
        HttpCookie httpCookie = new HttpCookie("UserID", userID);
        myCookie.Expires = DateTime.Now.AddMinutes(timeOut);
        Response.Cookies.Add(myCookie);
        return httpCookie;
    }
