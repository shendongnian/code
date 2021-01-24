     XmlReader reader = XmlReader.Create(@"[Location of your XML file here..]"); 
      while (reader.Read())
      {
        if (reader.NodeType == XmlNodeType.Element)
        {
          if (reader.Name.ToLower() == "keyword")
          {
            Console.WriteLine(reader.Value);
            if (reader.HasAttributes)
            {
              Console.WriteLine(reader.GetAttribute("subject"));
            }
          }
        }
      }
      Console.ReadKey();
