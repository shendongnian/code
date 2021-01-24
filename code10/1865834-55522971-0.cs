          public static List<string> GetPathValues(XmlNode node)
          {
             List<string> dataPath = new List<string>();
             XmlNode pathNode = node.SelectSingleNode("Path");
             if (pathNode != null)
             {
                dataPath.Add(pathNode.ChildNodes.OfType<XmlText>().Single().Value.Trim());
                dataPath.AddRange(GetPathValues(pathNode));
             }
             return dataPath;
          }
