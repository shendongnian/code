    var nodes = document.Descendants("nodes").Descendants("node");
                
    var ids=new List<string>();
    foreach (var node in nodes)
    {
           var aSubNode = node.Descendants("subnode")
                .FirstOrDefault(a => a.Attribute("name")?.Value == "a" && a.Attribute("value")?.Value == "1");
           var bSubNode=node.Descendants("subnode")
               .FirstOrDefault(a => a.Attribute("name")?.Value == "b" && a.Attribute("value")?.Value == "2");
               
           if (aSubNode==null || bSubNode==null)
               continue;
           ids.Add(aSubNode.Attribute("id")?.Value);
           ids.Add(bSubNode.Attribute("id")?.Value);
    }
