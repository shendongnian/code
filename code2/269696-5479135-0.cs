        bool busy = false;
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e) {
            if (busy) return;
            busy = true;
            try {
                checkNodes(e.Node, e.Node.Checked);
            }
            finally {
                busy = false;
            }
        }
        private void checkNodes(TreeNode node, bool check) {
            foreach (TreeNode child in node.Nodes) {
                child.Checked = check;
                checkNodes(child, check);
            }
