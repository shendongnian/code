           var list = new List<XmlElement>();
           for (int i = 1; i <= nodes.Count -1; i++)
           {
               foreach (XmlElement s in nodes[i])
               {
                 list.Add(nodes[i]); 
              }
           }
           foreach(var listTemp in list)
           {
	          nodes.remove...(listTemp);
           }
