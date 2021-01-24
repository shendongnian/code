    public MainWindow()
    {
        InitializeComponent();
        ChromiumWebBrowser.BrowserSettings.WebSecurity = CefState.Disabled;
        ChromiumWebBrowser.RequestHandler = new RequestHandler();
        ChromiumWebBrowser.Address = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestHtml", "index.html");
    }
