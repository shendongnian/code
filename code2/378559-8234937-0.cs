    private void CategoryButtonClick(object sender, EventArgs e)
    {
        if (treeView1.SelectedNode != null)
        {
            var nodeText = textBox1.Text.Trim();
            if (treeView1.SelectedNode.Parent == null)
                treeView1.Nodes.Add(nodeText);
            else
                treeView1.SelectedNode.Parent.Nodes.Add(nodeText);
        }
    }
    private void SubcategoryButtonClick(object sender, EventArgs e)
    {
        var nodeText = textBox1.Text.Trim();
        if (treeView1.SelectedNode != null)
            treeView1.SelectedNode.Nodes.Add(nodeText);
    }
