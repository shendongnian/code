    public static void RegisterClientScriptInclude(Page page, string name, string url)
    {
        Type cstype = page.GetType();
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = page.ClientScript;
        // Check to see if the include script exists already.
        if (!cs.IsClientScriptIncludeRegistered(cstype, name))
        {
            cs.RegisterClientScriptInclude(cstype, name, page.ResolveClientUrl(url));
        }
    }
