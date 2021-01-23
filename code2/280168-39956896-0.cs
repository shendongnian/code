    private void treeView_AfterCheck(object sender, TreeViewEventArgs e) {
            try {
                e.Node.TreeView.BeginUpdate();
                if (e.Node.Nodes.Count > 0) {
                    var parentNode = e.Node;
                    var nodes = e.Node.Nodes;
                    CheckedOrUnCheckedNodes(parentNode, nodes);
                }
            } finally {
                e.Node.TreeView.EndUpdate();
            }
        }
    private void CheckedOrUnCheckedNodes(TreeNode parentNode, TreeNodeCollection nodes) {
            if (nodes.Count > 0) {
                foreach (TreeNode node in nodes) {
                    node.Checked = parentNode.Checked;
                    CheckedOrUnCheckedNodes(parentNode, node.Nodes);
                }
            }
        }
