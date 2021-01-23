    private TreeNode FindNode(TreeNode root, String name)
            {
                foreach (TreeNode node in root.Nodes)
                {
                    if (node.Name == name)
                        return node;
                    else
                    {
                        if (node.Nodes.Count > 0)
                            return FindNode(node, name);
                    }
                }
                return null;
            }
          
