        public void MoveNode(TreeView tv, TreeNode node, bool up)
        {
            
            if ((node.PrevNode == null) && up) {
                return;
            }
            if ((node.NextNode == null) && !up) {
                return; 
            }
            int newIndex = up ? node.Index - 1 : node.Index + 1;
            var nodes = tv.Nodes; 
            if (node.Parent != null) {
                nodes = node.Parent.Nodes;
            }
            nodes.Remove(node);
            nodes.Insert(newIndex, node); 
        }
