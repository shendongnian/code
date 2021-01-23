    private void tree_Documents_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode checkedNode = e.Node;
            foreach (TreeNode node in checkedNode.Nodes)
            {
                node.Checked = checkedNode.Checked;
            }
        }
