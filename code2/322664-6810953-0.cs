    string CookieName = "bob";
    long UserId = 4;
    HttpCookie myCookie = HttpContext.Current.Request.Cookies[CookieName] ?? new HttpCookie(CookieName);
    myCookie.Values["UserId"] = UserId.ToString();
    myCookie.Values["LastVisit"] = DateTime.Now.ToString();
    myCookie.Expires = DateTime.Now.AddDays(365);
    HttpContext.Current.Response.Cookies.Add(myCookie);
