     bool exists = NodeExists(treeView1.Nodes[0], "DEPARTMENT");
        private bool NodeExists(TreeNode node, string key) {
            foreach (TreeNode subNode in node.Nodes) {
                if (subNode.Text == key) {
                    return true;
                }
                if (node.Nodes.Count > 0) {
                    NodeExists(node, key);
                }
            }
            return false;
        }
