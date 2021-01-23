    static class Program
    {
        [STAThread]
        static void Main()
        {
            Context ctx = new Context();
            Application.Run(ctx);
            // ctx.Html; -- your html
        }
    }
    class Context : ApplicationContext
    {
        public string Html { get; set; }
        public Context()
        {
            WebBrowser browser = new WebBrowser();
            browser.AllowNavigation = true;
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            browser.Navigate("http://www.google.com");
        }
        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Html = ((WebBrowser)sender).DocumentText;
            this.ExitThread();
        }
    }
