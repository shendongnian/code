        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                UncheckNodes(treeView1.Nodes,e.Node);
            }
        }
        private void UncheckNodes(TreeNodeCollection nodes, TreeNode except)
        {
            foreach (TreeNode node in nodes)
            {
                if (node != except) node.Checked = false;
                UncheckNodes(node.Nodes, except);
            }
        }
