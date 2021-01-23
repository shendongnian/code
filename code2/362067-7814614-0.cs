    private void OnDocCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser wb = sender as WebBrowser;
        if (wb.Document != null)
        {
            List<string> links = new List<string>();
            foreach (HtmlElement element in wb.Document.GetElementsByTagName("a"))
            {
                links.Add(element.GetAttribute("href"));
            }
            foreach (string link in links)
            {
                Console.WriteLine(link);
            }
        }
    }
