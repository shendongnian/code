    public static void addJavascriptIDs(Page page, params Control[] ctls)
    {
    	string js = "";
        foreach (Control ctl in ctls)
            js += string.Format("var ASP_{0} = '{1}';", ctl.ID, ctl.ClientID);
    	page.ClientScript.RegisterClientScriptBlock(typeof(object), "IDs", js, true)
    	/* http://msdn.microsoft.com/en-us/library/bahh2fef.aspx */
    }
    public static void addJavascriptIncludes(Page page, params string[] scripts)
    {
        foreach (string script in scripts)
    		page.ClientScript.RegisterClientScriptInclude(typeof(object), script, page.ResolveUrl(script));
    	/* http://msdn.microsoft.com/en-us/library/kx145dw2.aspx */
    }
