    string input = "First regular, <b>bold</b>,<i>italic</i>,<u>underline</u>,<b><i><u>bold+italic+underline</u></i></b>";
    input = "<data>" + input + "</data>";
    XmlDocument xml = new XmlDocument();
    xml.InnerXml = input;
    XmlNodeList nodes = xml.SelectNodes("//text()");
    foreach (XmlNode node in nodes) {
    	if (node.ParentNode.Name != "b" && node.ParentNode.Name != "i" && node.ParentNode.Name != "u") {
    		node.InnerText = "^^^^^" + node.InnerText + "$$$$$";
    	}
    }
    input = xml.DocumentElement.InnerXml.Replace("^^^^^", "<plain>").Replace("$$$$$", "</plain>");
