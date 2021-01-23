    public partial class Form1 : Form
    {
        BrowserWrapper bw;
    
        public Form1()
        {
            InitializeComponent();
            bw = new BrowserWrapper(webBrowser1);
        }
    
        public string[] Get()
        {
            return new[] { "www.google.com", "www.yahoo.com", "www.hotmail.com"};
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            bw.LoadPages(Get());
        }
    }
    
    public class BrowserWrapper
    {
        public void LoadPages(string[] pages) {
            this.pages = pages;
            nextIndex = 0;
            NextPage();
        }
        WebBrowser Browser;
    
        public BrowserWrapper(WebBrowser browser)
        {
            Browser = browser;
            Browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Browser_DocumentCompleted);
        }
    
        void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(Browser.ReadyState == WebBrowserReadyState.Complete && e.Url == Browser.Url)
            {  NextPage(); }
        }
    
        string[] pages;
        int nextIndex;
        void NextPage() {
            if(pages != null && nextIndex < pages.Length) {
                Browser.Navigate(pages[nextIndex++]);
            }
        }
    }
