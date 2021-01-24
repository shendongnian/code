 c#
public IController Create(RequestContext requestContext, Type controllerType)
{
    string lang = requestContext.RouteData.Values["language"] as string ?? _DefaultLanguage;
    if (lang != _DefaultLanguage)
    {
        try
        {
            Thread.CurrentThread.CurrentCulture =
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            // Store the culture in the session here
            requestContext.HttpContext.Session["culture"] = Thread.CurrentThread.CurrentCulture;
        }
        catch (Exception)
        {
            throw new NotSupportedException(string.Format("ERROR: Invalid language code '{0}'.", lang));
        }
    }
    return DependencyResolver.Current.GetService(controllerType) as IController;
}
c#
public ActionResult Login(UserLogin user = null, string ReturnUrl = "/")
{
    Thread.CurrentThread.CurrentCulture =
    Thread.CurrentThread.CurrentUICulture = Session["culture"] as CultureInfo;
    //do the rest of the login stuff below
    // ...
    return View();
}
