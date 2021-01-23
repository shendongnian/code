    ... 
    aCookie = new HttpCookie(cookieName);    
    if (aCookie.Name != "__utmz")
    {
        aCookie.Value = "";    //set a blank value to the cookie 
        aCookie.Expires = DateTime.Now.AddDays(-1);   
        HttpContext.Current.Response.Cookies.Add(aCookie);    
    }
