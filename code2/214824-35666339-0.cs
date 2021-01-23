        public void FindNode(TreeNodeCollection nodeCollection)
        {
            foreach (TreeNode node in nodeCollection)
            {
                foreach (TreeNode nd in node.ChildNodes)
                {
                    if (nd.Text.Contains(".txt"))
                    {
                        nd.Select(); 
                        return;
                    }
                }
            }  
        }
