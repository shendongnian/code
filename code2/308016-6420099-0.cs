    private void button1_Click(object sender, EventArgs e)
    {
        var rootElement = new XElement("root", CreateXmlElement(treeView1.Nodes));
        var document = new XDocument(rootElement);
        document.Save("C:\\1.xml");
    }
    private static List<XElement> CreateXmlElement(TreeNodeCollection treeViewNodes)
    {
        var elements = new List<XElement>();
        foreach (TreeNode treeViewNode in treeViewNodes)
        {
            var element = new XElement(treeViewNode.Name);
            if (treeViewNode.GetNodeCount(true) == 1)
                element.Value = treeViewNode.Nodes[0].Name;
            else
                element.Add(CreateXmlElement(treeViewNode.Nodes));
            elements.Add(element);
        }
        return elements;
    }
