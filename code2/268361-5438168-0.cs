    private void Form1_Load(object sender, EventArgs e)
    {
        var doc = XDocument.Load("data.xml");
        var root = doc.Root;
        var x = GetNodes(new TreeNode(root.Name.LocalName), root).ToArray();
        treeView1.Nodes.AddRange(x);
    }
    private IEnumerable<TreeNode> GetNodes(TreeNode node, XElement element)
    {
        return element.HasElements ?
            node.AddRange(from item in element.Elements()
                          let tree = new TreeNode(item.Name.LocalName)
                          from newNode in GetNodes(tree, item)
                          select newNode)
                          :
            new[] { node };
    }
