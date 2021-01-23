    public const string ViewDataKey_EmailSubject = "MyAppName_EmailSubject";
    /// <summary>
    /// Sets an email subject in <paramref name="page"/>'s  <see cref="WebViewPage{T}.ViewBag"/>.  Useful for retrieving the subject from controller.
    /// </summary>
    public static void EmailSubject<T>(this WebViewPage<T> page, string subject)
    {
        // Must set value on ViewContext's ViewData if we want to access it after view renders; page.ViewData setter copies the ViewDataDictionary.
        page.ViewContext.ViewData[ViewDataKey_EmailSubject] = subject;
    }
