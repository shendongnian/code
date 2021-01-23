      using (XmlReader reader = XmlReader.Create(<your_xml_file>)) {
        while (reader.Read()) {
          // first element is the root element
          if (reader.NodeType == XmlNodeType.Element) {
            System.Console.WriteLine(reader.Name);
            break;
          }
        }
      }
