    public class MYCLASSProduct: IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
        private WebBrowser _WebBrowser;
        private AutoResetEvent _lock;
        public void Load(string url)
        {
            _lock = new AutoResetEvent(false);
            this.Url = url;
            browserInitializeBecauseJavascriptLoadThePage();
        }
        private void browserInitializeBecauseJavascriptLoadThePage()
        {
            _WebBrowser = new WebBrowser();
            _WebBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            _WebBrowser.Dock = DockStyle.Fill;
            _WebBrowser.Name = "webBrowser";
            _WebBrowser.ScrollBarsEnabled = false;
            _WebBrowser.TabIndex = 0;
            _WebBrowser.Navigate(Url);
            Form form = new Form();
            form.Hide();
            form.Controls.Add(_WebBrowser);
            Application.Run(form);
            _lock.WaitOne();
        }
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlAgilityPack.HtmlDocument hDocument = new HtmlAgilityPack.HtmlDocument();
            hDocument.LoadHtml(_WebBrowser.Document.Body.OuterHtml);
            this.Price = Convert.ToDouble(hDocument.DocumentNode.SelectNodes("//td[@class='ask']").FirstOrDefault().InnerText.Trim());
            _WebBrowser.FindForm().Close();
            _lock.Set();
        }
