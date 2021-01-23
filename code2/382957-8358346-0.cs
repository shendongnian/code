    public static string Translate(string input, string languagePair, Encoding encoding)
    {
    string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
    
    string result = String.Empty;
    
    using (WebClient webClient = new WebClient())
    {
    webClient.Encoding = encoding;
    result = webClient.DownloadString(url);
    }
    
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(result);
    return doc.DocumentNode.SelectSingleNode("//textarea[@name='utrans']").InnerText;
    }
    
    //Get the HtmlAgilityPack here: http://www.codeplex.com/htmlagilitypack
