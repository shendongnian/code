    public IEnumerable<string> GetResults(string html) {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        foreach(HtmlNode link in doc.DocumentElement.SelectNodes("//span[@class='tl']/h3/a"))
        {
            var value = link["href"].Value;
            yield return value;
         }
     }
     
