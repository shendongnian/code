    HttpCookie cookie = new HttpCookie(name);
    cookie.Values["key1"] = value;
    cookie.Values["key2"] = DateTime.Now.AddMinutes(70).ToString(); //timeout 70 minutes with browser open
    cookie.Expires = DateTime.MinValue;
    cookie.Domain = ConfigurationManager.AppSettings["website_domain"];
    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
    
    When checking the cookie key value use:
    
    try
    {
    
    DateTime dateExpireDateTime;
    dateExpireDateTime = DateTime.Parse(HttpContext.Current.Request.Cookies[name]["key2"]);
    
    if (DateTime.Now > dateExpireDateTime)
    {
    //cookie key value timeout code
    }
    else
    {
    //reset cookie
    }
    
    catch
    {
    //clear cookie and redirect to log in page
    }
