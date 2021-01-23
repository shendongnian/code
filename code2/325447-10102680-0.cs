    Dictionary<string, string> cids = new Dictionary<string, string>();
    int imgCount = 0;
    HtmlDocument doc = new HtmlDocument();
    doc.Load(htmlFilename, System.Text.Encoding.UTF8);
    foreach(HtmlNode link in doc.DocumentNode.SelectNodes("//img"))
    {
        HtmlAttribute att = link.Attributes["src"];
        Console.Write("img src = " + att.Value);
        if (!cids.ContainsKey(att.Value))
        {
            cids[att.Value] = imgCount.ToString() + "." + GetRandomString(10) + "@domain.com";
            imgCount++;
        }
        att.Value = "cid:" + cids[att.Value];
        Console.WriteLine("  became " + att.Value);
    }
    StringWriter sw = new StringWriter();
    doc.Save(sw);
    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(sw.ToString(), System.Text.Encoding.GetEncoding("utf-8"), "text/html");
