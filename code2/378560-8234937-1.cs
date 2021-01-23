    protected void categoryButton_Click1(object sender, EventArgs e)
    {
        if (treeView1.SelectedNode != null)
        {
            var nodeText = textBox1.Text.Trim();
            if (treeView1.SelectedNode.Parent == null)
                treeView1.Nodes.Add(new TreeNode(nodeText));
            else
                treeView1.SelectedNode.Parent.ChildNodes.Add(new TreeNode(nodeText));
        }
    }
    protected void subCategoryButton_Click(object sender, EventArgs e)
    {
        var nodeText = textBox1.Text.Trim();
        if (treeView1.SelectedNode != null)
            treeView1.SelectedNode.ChildNodes.Add(new TreeNode(nodeText));
    }
