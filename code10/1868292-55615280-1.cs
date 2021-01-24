    var nodes = document.Descendants("nodes").Descendants("node");
                
            var ids=new List<string>();
            foreach (var node in nodes)
            {
               var asubNode = node.Descendants("subnode")
                    .FirstOrDefault(a => a.Attribute("name")?.Value == "a" && a.Attribute("value")?.Value == "1");
               var bsubNode=node.Descendants("subnode")
                   .FirstOrDefault(a => a.Attribute("name")?.Value == "b" && a.Attribute("value")?.Value == "2");
               
               if (asubNode==null || bsubNode==null)
                   continue;
               ids.Add(asubNode.Attribute("id")?.Value);
               ids.Add(bsubNode.Attribute("id")?.Value);
            }
