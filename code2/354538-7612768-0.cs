    XDocument doc = XDocument.Load("test.xml");
    var nodesWithMatchingElements = doc.Root.Elements("tu")
                                       .GroupBy(e => e)
                                       .Select(g => new 
                                        { 
                                           Element = g.Key, 
                                           Count = g.Descendants("seg").Select(x => x.Value).Distinct().Count() 
                                        })
                                       .Where(x => x.Count == 1);
    foreach (var node in nodesWithMatchingElements)
        node.Element.Remove();
