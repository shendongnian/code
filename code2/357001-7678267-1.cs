    if (Request.Cookies["test"] != null)
    {
        HttpCookie test = new HttpCookie("test");
        test.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(test);
    }
