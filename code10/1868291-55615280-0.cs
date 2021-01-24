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
               values.Add(a_subNode.Attribute("id")?.Value);
               values.Add(b_subNode.Attribute("id")?.Value);
            }
