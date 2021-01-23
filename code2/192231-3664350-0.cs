    foreach(XmlNode node in nodes)
     {
         XmlNodeList innerNodes = node.SelectNodes("/word");
         foreach(Xmlnode innerNode in innerNodes )
         {
              Console.WriteLine(innerNode.InnerText);
         }
     }
