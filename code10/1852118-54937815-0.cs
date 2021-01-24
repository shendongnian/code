        private void GetCountries()
        {
            WebBrowser browser = new WebBrowser();
            browser.Navigate("https://gist.github.com/kalinchernev/486393efcca01623b18d");
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
        }
        int conta;  //number of countries
        public void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            var links = browser.Document.GetElementsByTagName("tr");
            foreach (HtmlElement link in links)
            {
                if (link.InnerHtml.Contains("blob-num"))
                {
                    string countrie = link.InnerText;
                    listbox.Items.Add($"{++conta} / {countrie}");
                }
            }
        }
