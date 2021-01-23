    public MainPage()
    {
        HtmlPage.RegisterScriptableObject("Page", this);
        InitializeComponent();
    }
    [ScriptableMember]
    public void SetInfo(string xml)
    {
        // do stuff
    }
