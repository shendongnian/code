    // Remember to initialise the XmlNamespaceManager described above
    XmlDocument oldSkool = new XmlDocument();
    oldSkool.LoadXml(xaml);
    XmlNode saveButtonNode = 
       oldSkool.SelectSingleNode("//def:Canvas/basics:Button[@x:Name = 'Save']", nsm);
    if(saveButtonNode != null)
    {
      Console.WriteLine(saveButtonNode.Attributes["Width"].Value);
    }
