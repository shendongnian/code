    class WebRunner
    {
        private List<string> _corruptList = new List<string>();
        private List<WebBrowser> _browsers = new List<WebBrowser>();
        public void Run()
        {
            _corruptList.Add("http://google.com");
            _corruptList.Add("http://yahoo.com");
            _corruptList.Add("http://bing.com");
            DoDelete();
            Console.ReadKey();
        }
        public void DoDelete()
        {
            if (_corruptList.Count < 1) return;
            int counter = 1;
            foreach (string listItem in _corruptList)
            {
                WebBrowser webBrowser = new WebBrowser();
                _browsers.Add(webBrowser);
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBroswer_DocumentCompleted);
                webBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser_Navigated);
                webBrowser.Navigate(listItem);
                if (counter % 10 == 0) Thread.Sleep(3000); // let app catch up every so often
                counter++;
            }
        }
        void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Console.WriteLine("NAVIGATED: " + e.Url);
        }
        void webBroswer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("COMPLETED!");
            try
            {
                WebBrowser webBrowser = sender as WebBrowser;
                HtmlDocument doc = webBrowser.Document;
                var button = doc.Body.Document.GetElementById("button");
                button.InvokeMember("Click");
                _browsers.Remove(webBrowser);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.Message);
            }
        }
    }
