    XmlNode root = oDoc.DocumentElement;
    XmlNode patient = oDoc.GetElementsByTagName("Patient")[0];
    XmlNamespaceManager nsm = new XmlNamespaceManager(new NameTable());
    nsm.AddNamespace("ns", "http://");
    XmlNode identification = patient.SelectSingleNode("ns:Identification", nsm);
    string id = identification.SelectSingleNode("ns:ID", nsm).InnerText;
