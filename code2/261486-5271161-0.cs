        List<string> listOfUrls = new List<string>();
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.Load(@"c:\ht.html");
        HtmlNodeCollection coll =  doc.DocumentNode.SelectNodes("//a[@href]");
        foreach (HtmlNode link in coll)
        {
            HtmlAttribute att = link.Attributes["href"];
            listOfUrls.Add(att.Value);
        }
        //Now, You got your listOfUrls to process.
