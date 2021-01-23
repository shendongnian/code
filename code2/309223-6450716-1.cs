        private void PageScrape(string url)
        {
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);
            var date = document.DocumentNode.SelectSingleNode(".//*[@class='Article_Date']");
                if (date != null)
                {
                   goodBox.Text += date.InnerText;
                }
                else
                {
                   goodBox.Text += "whoops!";
                }
            }
