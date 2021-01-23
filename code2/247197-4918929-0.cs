    // Add cookie
    HttpContext.Current.Response.Cookies.Add(new HttpCookie("MyCookieBizkit", imageList));
    // Remove cookie
    HttpContext.Current.Response.Cookies.Remove("MyCookieBizkit");
    // Edit
    HttpContext.Current.Response.Cookies["MyCookieBizkit"] = imageList;
    // Get
    imageList = HttpContext.Current.Request.Cookies["MyCookieBizkit"] != null ? (List<string>)HttpContext.Current.Request.Cookies["MyCookieBizkit"] : new List<string>();
