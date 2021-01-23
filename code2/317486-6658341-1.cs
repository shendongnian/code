    public Uri MyURI { get; set; }
    public Form1()
    {
        InitializeComponent();
    
        MyURI = new Uri("http://stackoverflow.com");
        webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        webBrowser1.Url = MyURI;
    }
    
    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if(e.Url == MyURI)
            MessageBox.Show("Page Loaded");
    }
