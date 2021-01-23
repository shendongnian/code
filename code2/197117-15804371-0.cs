        private TreeNode GetNode(string key)
        {
            TreeNode n = null ;
            n = GetNode(key, Tree.Nodes);
            return n;
        }
        private TreeNode GetNode(string key,TreeNodeCollection nodes)
        {
            TreeNode n = null;
            if (nodes.ContainsKey(key))
                n = nodes[key];
            else
            {
                foreach (TreeNode tn in nodes)
                {
                    n = GetNode(key, tn.Nodes);
                    if (n != null) break;
                }
            }
            return n;
        }
