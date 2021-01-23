    // Gives you the current session id as a string
    OperationContext.Current.SessionId      // I'm not clear on what, if any,
    HttpContext.Current.Session.SessionID   // difference there is between these
    // Indicates whether the service is using sessionless cookies
    HttpContext.Current.Session.CookieMode
    // Indicates whether the session id is stored in the url or in an HTTP cookie 
    HttpContext.Current.Session.IsCookieless
    // The cookies themselves
    HttpContext.Current.Request.Cookies
    HttpContext.Current.Response.Cookies
    // The session and cache objects
    HttpContext.Current.Cache
    HttpContext.Current.Session
