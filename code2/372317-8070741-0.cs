    BLL.Common.executeJSFunction("DoSomething();", "Exec1");
    BLL.Common.executeJSFunction("DoSomething();", "Exec2");
    BLL.Common.executeJSFunction("DoSomething();", "Exec3");
    public static void executeJSFunction(string jsFunction, string key)
    {
        var page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), key, jsFunction, true);
    }
