        private void PageScrape(string url)
        {
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);
            var headerString = document.DocumentNode.SelectSingleNode("//head");
                if (headerString != null)
                {
                   goodBox.Text += headerString;
                }
                else
                {
                   goodBox.Text += "whoops!";
                }
            }
