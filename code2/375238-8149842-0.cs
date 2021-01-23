    FormsAuthentication.SignOut();
    CurrentContext.Session.Abandon();
    HttpCookie c = CurrentContext.Request.Cookies[FormsAuthentication.FormsCookieName];
    if (c != null)
    {
         c.Expires = DateTime.Now.AddDays(-1);
         CurrentContext.Response.Cookies.Add(c);
    }
