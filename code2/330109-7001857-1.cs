    string fileFormat = string.Empty;
    XmlDocument xDoc = new XmlDocument();
    xDoc.Load(fileName);
    XmlNodeList auxFilesList = xDoc.GetElementsByTagName("AuxFiles");
    for (int i = 0; i < auxFilesList.Count; i++)
    {
       XmlNode item = classList.Item(i);
       if (item.Attributes["AttachmentType"].Value == "csv")
       {
          fileFormat = item.Attributes["FileFormat"].Value;
       }
    }
