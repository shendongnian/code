     string test = string.Empty;
    StreamReader sr = new StreamReader(@"C:\gs.htm");
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load(sr);
    sr.Close();
    sr = null;
    string xpath = @"//table[@id='Home']/tr[3]/td";
    test = doc.DocumentNode.SelectSingleNode(xpath).InnerText;
