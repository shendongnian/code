    HtmlDocument htmlDoc = new HtmlWeb().Load("https://www.nordicwater.com/products/waste-water/");
    HtmlNodeCollection ProductListPage = htmlDoc.DocumentNode.SelectNodes("//a[@class='ap-area-link']");
    if (ProductListPage != null)
        foreach (HtmlNode src in ProductListPage)
        {
            string href = src.GetAttributeValue("href", string.Empty);
            if (string.IsNullOrEmpty(href))
                continue;
            htmlDoc = new HtmlWeb().Load(href);
            HtmlNodeCollection LinkTester = htmlDoc.DocumentNode.SelectNodes("//div[@class='dl-items']//a");
            if (LinkTester != null)
                foreach (var dllink in LinkTester)
                {
                    string LinkURL = dllink.GetAttributeValue("href", string.Empty);
                    if (string.IsNullOrEmpty(LinkURL))
                        continue;
                    string ExtractFilename = LinkURL.Substring(LinkURL.LastIndexOf("/") + 1);
                    new WebClient().DownloadFileAsync(new Uri(LinkURL), @"C:\temp\" + ExtractFilename);
                }
        }
