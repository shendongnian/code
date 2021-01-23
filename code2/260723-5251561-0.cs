    DownloadSearchHits("SHA", "pdf");
    ...
    public static void DownloadSearchHits(string searchTerm, string fileType)
    {
        using (WebClient wc = new WebClient())
        {
            string html = wc.DownloadString(string.Format("http://www.google.com/search?q={0}+filetype%3A{1}", searchTerm, fileType));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var pdfLinks = doc.DocumentNode
                                .SelectNodes("//a")
                                .Where(link => link.Attributes["href"] != null 
                                       && link.Attributes["href"].Value.EndsWith(".pdf"))
                                .Select(link => link.Attributes["href"].Value)
                                .ToList();
            int index = 0;
            foreach (string pdfUrl in pdfLinks)
            {
                wc.DownloadFile(pdfUrl, string.Format(@"C:\pdfdownload\{0}.pdf", index++));
            }
        }
    }
