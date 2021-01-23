    XmlSerializer serializer = new XmlSerializer(typeof(MapTiles));
    using (StringWriter stringWriter = new StringWriter())
    {
      serializer.Serialize(stringWriter, tempGroup);
  
      using (ResXResourceWriter resourceWriter = new ResXResourceWriter("~/App_GlobalResources/some_file.resx"))
      {
         resourceWriter.AddResource("Maps", stringWriter.ToString());
      }
    }
