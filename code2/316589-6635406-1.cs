    if (Request.Cookies["UserSettings"] != null)
    {
        HttpCookie myCookie = new HttpCookie("UserSettings");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
    }
