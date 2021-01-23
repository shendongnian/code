    public static void executeJSFunction(string key, string jsFunction)
        {
            var page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), key, jsFunction, true);
        }
    
    BLL.Common.executeJSFunction("Exec1", "DoSomething();");
    BLL.Common.executeJSFunction("Exec1", "DoSomething();");
    BLL.Common.executeJSFunction("Exec1", "DoSomething();");
