    void node_AfterCheck(object sender, TreeViewEventArgs e) {
        // only do it if the node became checked:
        if (e.Node.Checked) {
            // for all the nodes in the tree...
            foreach (TreeNode cur_node in e.Node.TreeView.Nodes) {
                // ... which are not the freshly checked one...
                if (cur_node != e.Node) {
                    // ... uncheck them
                    cur_node.Checked = false;
                }
            }
        }
    }
