      using (var memoryStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("<Test><GoodAttribute>a\u0009b</GoodAttribute><BadAttribute>c\u0007d</BadAttribute></Test>")))
      {
        using (var xmlFilteredTextReader = new FilterInvalidXmlReader(memoryStream))
        {
          using (var xr = System.Xml.XmlReader.Create(xmlFilteredTextReader))
          {
            while (xr.Read())
            {
              if (xr.NodeType == System.Xml.XmlNodeType.Element)
              {
                var xe = System.Xml.Linq.XElement.ReadFrom(xr);
                System.Console.WriteLine(xe.ToString());
              }
            }
          }
        }
      }
