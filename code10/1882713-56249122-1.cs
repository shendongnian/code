    Dictionary<string, string> chDictionary = new Dictionary<string, string>();
    // I notice that you have "CH" as your element name here
    // It should be "Ch" like below
    XmlNodeList chNodes = xmlDocument.GetElementsByTagName("Ch");
    int chCount = chNodes.Count;
    foreach (XmlElement chNode in chNodes)
    {
        chDictionary.Add(
             chNode.FirstChild.InnerText,
             chNode.LastChild.InnerText);
    }
