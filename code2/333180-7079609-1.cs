    if (Request.Cookies["clienDetails"] != null)
    {
        HttpCookie myCookie = new HttpCookie("clienDetails");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
    }
