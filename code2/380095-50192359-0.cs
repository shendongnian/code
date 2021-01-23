    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        var node = (e == null ? ((System.Windows.Forms.TreeView)sender).SelectedNode : e.Node);
        var rootNode = RootTreeNode(node);
    }
