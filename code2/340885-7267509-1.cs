    HtmlWeb web = new HtmlWeb();
    HtmlAgilityPack.HtmlDocument doc = web.Load("http://www.SourceURL");  
    doc.OptionOutputAsXml = true;
    System.IO.StringWriter sw = new System.IO.StringWriter();
    System.Xml.XmlTextWriter xw = new System.Xml.XmlTextWriter(sw);
    doc.Save(xw);
    string result = sw.ToString();
