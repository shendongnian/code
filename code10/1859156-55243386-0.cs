    If(HttpContext.Current.Response.Cookies.AllKeys.Contains("myCookie") == false)
        db.SaveChanges();
    else 
    {
        HttpCookie myCookie = new HttpCookie("myCookie");
        myCookie.Value = "SomeInfo";
        myCookie.Expires = DateTime.Now.AddDays(1d);
        Response.Cookies.Add(myCookie);
    }
