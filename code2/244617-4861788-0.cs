    XmlDocument doc = new XmlDocument();
    string xmldoc = data.ToString();
    doc.LoadXml(xmldoc);
    XmlNodeList _fpartno = doc.GetElementsByTagName("component");
    System.Collections.ArrayList Itemslist = new System.Collections.ArrayList(_fpartno.Count);
    for (int i = 0; i < _fpartno.Count; ++i){
        if( doc.GetElementsByTagName("fbomsource")[i] == null){ 
            //this is an error in the XML, throw an Exception or or log it
        }
        // more validation if needed
    } 
    for (int i = 0; i < _fpartno.Count; ++i){
        // actual Code
    }
