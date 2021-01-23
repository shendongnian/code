    string path = @"C:\Path\To\Output.xml";
    List<Business> list = // set data 
    using (var streamWriter = new StreamWriter(new FileStream(path, FileMode.Write)))
    {
      using (var xmlWriter writer = new XmlTextWriter(streamWriter))
      {
        var serialiser = new XmlSerializer(typeof(List<Business>));
        serialiser.Serialize(xmlWriter, list);
      }
    }
