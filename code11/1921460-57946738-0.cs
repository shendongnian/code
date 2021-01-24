    public Form1()
    {
        InitializeComponent();
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        geckoWebBrowser1.Navigate("http://localhost:81/?test=true");
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        geckoWebBrowser1.Navigate("http://localhost:81/?test=false");
    }
    private void GeckoWebBrowser1_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
    {
        geckoWebBrowser1.Update();
        textBox1.Text = geckoWebBrowser1.Url.ToString();
    }
    [STAThread]
    static void Main()
    {
        Xpcom.Initialize("Firefox");
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
