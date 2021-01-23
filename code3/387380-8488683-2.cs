    HttpCookie myCookie = new HttpCookie("MyTestCookie");
    DateTime now = DateTime.Now;
    
    // Set the cookie value.
    myCookie.Value = now.ToString();
    // Set the cookie expiration date.
    myCookie.Expires = now.AddYears(50); // For a cookie to effectively never expire
    
    // Add the cookie.
    Response.Cookies.Add(myCookie);
    
    Response.Write("<p> The cookie has been written.");
