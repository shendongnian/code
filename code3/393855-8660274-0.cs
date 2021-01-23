      XmlReader reader = XmlReader.Create(@"C:\file.xml", null);
      StringBuilder result = new StringBuilder();
      while (reader.Read())
      {            
          if( reader.NodeType == XmlNodeType.Element)
          {
              if (reader.HasAttributes) 
              {
                  result.AppendLine(reader.LocalName);
                  reader.MoveToFirstAttribute();
                  result.AppendLine("  " + reader.Value);                    
              }
           }                      
        }
