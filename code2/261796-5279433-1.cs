    string pdfLinksUrl = "http://www.google.com/search?q=filetype%3Apdf";
    string htmlContent;
    // download HTML content    
    using (System.Net.WebClient wcClient = new System.Net.WebClient())
        htmlContent = wcClient.DownloadString(pdfLinksUrl);
    
    // load HTML content
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(htmlContent);
    
    // select all <A> nodes from the document using XPath
    var linkNodes = doc.DocumentNode.SelectNodes("//a");
    // select all nodes with href attribute ending with '.pdf'
    var pdfLinkNodes = from linkNode in linkNodes
        where linkNode.Attributes.Contains("href") // being paranoid
            && linkNode.Attributes["href"].Value.ToLower().EndsWith(".pdf")
        select linkNode.Attributes["href"].Value;
    
    // write all PDF links to file
    System.IO.File.WriteAllLines(@"c:\pdflinks.txt", pdfLinkNodes.ToArray());
