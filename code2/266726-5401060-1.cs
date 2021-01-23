    using System;
    using HtmlAgilityPack;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string url = @"http://www.veranomovistar.com.pe/";
        System.Net.WebClient wc = new System.Net.WebClient();
        HtmlDocument doc = new HtmlDocument();
        doc.Load(wc.OpenRead(url));
        var metaTags = doc.DocumentNode.SelectNodes("//title");
        if (metaTags != null)
        {
            string title = metaTags[0].InnerText;
        }
    }
