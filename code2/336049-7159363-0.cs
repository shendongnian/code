        // Returns the node with the first hit, or null if none
        public TreeNode Search(TreeView treeView, string text)
        { 
            return SearchNodes(treeView.Nodes, text);
        }
        // Recursive text search depth-first.
        private TreeNode SearchNodes(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text.Contains(text)) return node;
                var subSearchHit = SearchNodes(node.Nodes, text);
                if (subSearchHit != null) return subSearchHit;
            }
            return null;
        }
