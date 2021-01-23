    string pdfLinksUrl = "http://www.google.com/search?q=filetype%3Apdf";
    // Load HTML content    
    var webGet = new HtmlAgilityPack.HtmlWeb();
    var doc = webGet.Load(pdfLinksUrl);
    
    // select all <A> nodes from the document using XPath
    // (unfortunately we can't select attribute nodes directly as
    // it is not yet supported by HAP)
    var linkNodes = doc.DocumentNode.SelectNodes("//a[@href]");
    // select all nodes ending with '.pdf' (case-insensitive)
    var pdfLinkNodes = from linkNode in linkNodes
        let href = linkNode.Attributes["href"].Value
        where href.ToLower().EndsWith(".pdf")
        select href;
    
    // write all PDF links to file
    System.IO.File.WriteAllLines(@"c:\pdflinks.txt", pdfLinkNodes.ToArray());
