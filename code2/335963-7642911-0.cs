    using (XmlReader reader = XmlReader.Create("component.xml"))
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
        string path4 = treeView1.SelectedNode.FullPath.ToString();
        // now replace '\' by '/'
        path4 = path4.Replace('\\', '/');
        XmlNode nodeToRemove = doc.SelectSingleNode(path4);
        XmlNode parentNode = nodeToRemove.ParentNode;
        parentNode.RemoveChild(nodeToRemove);
    }
