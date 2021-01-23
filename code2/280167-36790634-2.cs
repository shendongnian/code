    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        if (e.Node.Nodes.Count != 0)
        {
            if (e.Node.Checked)
            {
                CheckAllChildNodes1(e.Node);
            }
            else
            {
                UncheckChildNodes1(e.Node);
            }
        }
    }
    private void CheckAllChildNodes1(TreeNode treeNodeAdv)
    {
        foreach (TreeNode nd in treeNodeAdv.Nodes)
        {
            nd.Checked = treeNodeAdv.Checked;
        }
    }
    private void UncheckChildNodes1(TreeNode treeNodeAdv)
    {
        foreach (TreeNode nd in treeNodeAdv.Nodes)
        {
            nd.Checked = treeNodeAdv.Checked;
        }
    }
