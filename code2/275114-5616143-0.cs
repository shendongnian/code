    public static class TreeViewExtensions {
        public static void Add(this TreeNodeCollection nodes, ITreeNode node) {
            TreeNode treeNode = new TreeNode(node.Text);
            foreach (ITreeNode child in node.Nodes) treeNode.Nodes.Add(child);
        }
    }
