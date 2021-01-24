    static List<List<string>> AddPapers(XmlNodeList nodelist)
    {
        var papers = new List<List<string>>();        
        foreach (XmlNode node in nodelist)
        {
            // Create a new list on each iteration
            var paper = new List<string>();
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                paper.Add(node.ChildNodes[i].InnerText);
            }
            papers.Add(paper);
        }
        return papers;
    }
