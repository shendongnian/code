        private void CopyNodes(TreeView srcTree, TreeView dstTree)
        {
            var ar = System.Array.CreateInstance(typeof(TreeNode), srcTree.Nodes.Count);
            treeView1.Nodes.CopyTo(ar, 0);
            foreach (TreeNode item in ar)
            {
                dstTree.Nodes.Add((TreeNode)item.Clone());
            }
        }
