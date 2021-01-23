    private TreeNode rightClickeNode;
    void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            rightClickedNode = e.Node;
        }
    }
