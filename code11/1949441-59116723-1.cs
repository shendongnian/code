    remcl3.Wcl3Client client = new remcl3.Wcl3Client();
    string rrs = client.getsql("sabatini", "ZXCqwe1920",112, w);            
    
    string xml = @rrs;
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    
    XmlNodeList elemList = doc.GetElementsByTagName("AC_NO");
    XmlNodeList elem = doc.GetElementsByTagName("AC_NAME");
    for (int i = 0; i < elemList.Count; i++) 
    {
        var value = elemList[i].InnerXml;
        var text = elem[i].InnerXml;
    
        rem_no.Items.Add(new ListItem(text, value));
    }
