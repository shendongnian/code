protected void Application_AuthenticateRequest(Object sender, EventArgs e)
{
    HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
    if (authCookie == null || authCookie.Value == "")
        return;
    FormsAuthenticationTicket authTicket;
    try
    {
        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    }
    catch
    {
        return;
    }
    string[] roles = authTicket.UserData.Split(';');
    if (Context.User != null)
        Context.User = new GenericPrincipal(Context.User.Identity, roles);
}
