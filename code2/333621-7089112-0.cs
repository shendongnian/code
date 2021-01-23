    private void button1_Click(object sender, EventArgs e)
    {
      this.FillTreeView();
    }
    private void FillTreeView()
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        XmlNode xmlnode ;
        FileStream fs = new FileStream("tree.xml", FileMode.Open, FileAccess.Read);
        xmldoc.Load(fs);
        xmlnode = xmldoc.ChildNodes[1];
        treeView1.Nodes.Clear();
        treeView1.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
        TreeNode tNode ;
        tNode = treeView1.Nodes[0];
        AddNode(xmlnode, tNode);
    }
    private void AddNode(...) { ... }
