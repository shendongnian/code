    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        (sender as TreeView).SelectedNode.ForeColor = Color.Red;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (TreeNode tn in treeView1.Nodes)
        {
            tn.ForeColor = Color.Blue;
            ColorNodes(tn);
        }
    }
    private void ColorNodes(TreeNode t)
    {
        foreach (TreeNode tn in t.Nodes)
        {
            tn.ForeColor = Color.Blue;
            ColorNodes(tn);
        }
    }
