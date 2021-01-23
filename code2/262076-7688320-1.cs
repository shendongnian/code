    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
        Application["HeaderNav"] = GetHtmlPage("https://site.com/HeaderNav.html");
    }
    static string GetHtmlPage(string strURL)
    {
        string strResult;
        var objRequest = HttpWebRequest.Create(strURL);
        var objResponse = objRequest.GetResponse();
        using (var sr = new StreamReader(objResponse.GetResponseStream()))
        {
            strResult = sr.ReadToEnd();
            sr.Close();
        }
        return strResult;
    }
