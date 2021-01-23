    /// <summary>
    /// Sends a system email containing a rendered view.
    /// </summary>
    public static void SendSystemEmailOfView(this Controller controller, string to, [AspMvcView] string viewName, object model, ViewDataDictionary viewData = null)
    {
        if (viewData == null)
        {
            viewData = new ViewDataDictionary();
        }
        
        var body = controller.Render(viewName, model, viewData);
        object subject;
        if (viewData.TryGetValue(WebViewPageExtensions.ViewDataKey_EmailSubject, out subject))
        {
            subject = subject as string;
        }
        if (subject == null)
        {
            subject = DefaultEmailSubject;
        }
        SendEmail(to, (string)subject, body, isHtml: true);
    }
