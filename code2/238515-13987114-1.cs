    _strXmlFromUrl = GetPageSource(_strWebserviceUrl); // My TestUrl: http://www.webservicex.net/globalweather.asmx?WSDL
    XmlDocument xmlDoc = new XmlDocument();
    XmlNamespaceManager nmspManager = new XmlNamespaceManager(xmlDoc.NameTable);
    nmspManager.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
    xmlDoc.LoadXml(_strXmlFromUrl);
    XmlNodeList methodNodes = xmlDoc.SelectNodes("//wsdl:portType[contains(@name, 'Soap')]/wsdl:operation[@name]",nmspManager);
    List<string> lstMehtodNames = new List<string>();
    for (int i = 0; i < methodNodes.Count; i++)
    {
    lstMehtodNames.Add(methodNodes[i].Attributes[0].Value);
    }
