    using System.Xml;
    using System.Xml.XPath;
    
    public string QuerySearch(string file, string artist) {
       
       // create an XML Document and load the file
       XmlDocument xd = new XmlDocument();
       xd.Load(file);
    
       // get the root xml element
       XmlElement root = xd.DocumentElement;
       
       // get the list of artists
       XmlNodeList aristList = root.GetElementsByTagName("artist");
       
       // get the list of titles's
       XmlNodeList titleList = root.GetElementsByTagName("title");
       
       // find match
       for (int i = 0;i < aristList.Count; i++) {
          if (aristList.Item(i).InnerText == artist) {
    		return titleList.Item(i).InnerText
    	  } 
       }
    return "no match found.";
    }
   
