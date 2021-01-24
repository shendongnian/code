        private void txtSerach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearch.Text.Trim() != "")
                {
                    if (treeView1.Nodes.Count > 0)
                    {
                        TreeNodeCollection nodes = treeView1.Nodes;
                        var selected = PrintRecursive(nodes, txtSearch.Text);
                        treeView1.SelectedNode = selected;
                        treeView1.SelectedNode.Expand();
                        treeView1.Focus();
                    }
                }
            }
        }
        private TreeNode PrintRecursive(TreeNodeCollection parents, string txtSearch)
        {
            foreach (TreeNode node in parents)
            {
                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    var rs = PrintRecursive(node.Nodes, txtSearch);
                    if (rs != null)
                    {
                        return rs;
                    }
                }
                if (node.Text.ToUpper().Contains(txtSearch.ToUpper().ToString()))
                {
                    return node;
                }
            }
            return null;
        }
