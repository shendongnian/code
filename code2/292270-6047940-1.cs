    private void MergeNodes(XmlNode parentNodeA, XmlNodeList childNodesB, XmlDocument parentA)
    {
        foreach (XmlNode oNode in childNodesB)
        {
            // Exclude container node
            if (oNode.Name == "#comment") continue;
    
            bool isFound = false;
            string name = oNode.Attributes["Name"].Value;
    
            foreach (XmlNode child in parentNodeA.ChildNodes)
            {
                if (child.Name == "#comment") continue;
    
                // If node already exists and is unchanged, exit loop
                if (child.InnerXml == oNode.InnerXml)
                {
                    isFound = true;
                    Console.WriteLine("Found::NoChanges::" + oNode.Name + "::" + name);
                    break;
                }
    
                // If node already exists but has been changed, replace it
                if (child.Attributes["Name"].Value == name)
                {
                    isFound = true;
                    Console.WriteLine("Found::Replaced::" + oNode.Name + "::" + name);
                    parentNodeA.ReplaceChild(parentA.ImportNode(oNode, true), child);
                }
            }
    
            // If node does not exist, add it
            if (!isFound)
            {
                Console.WriteLine("NotFound::Adding::" + oNode.Name + "::" + name);
                parentNodeA.AppendChild(parentA.ImportNode(oNode, true));
            }
        }
    }
