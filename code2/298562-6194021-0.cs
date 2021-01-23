        private void RecursiveCheckNodesDown(TreeNodeCollection tree, bool checkedFlag)
        {
            if (tree != null) 
                foreach (TreeNode node in tree)
                    RecursiveCheckNodesDown(node.Nodes, node.Checked = checkedFlag);
        }
        private void RecursiveCheckNodesUp(TreeNode node, bool checkedFlag)
        {
            if( node != null )
                RecursiveCheckNodesUp(node.Parent, node.Checked = checkedFlag);
        }
        private void SomeTreeBeginUpdate()
        {
            SomeTree.BeginUpdate();
            SomeTree.AfterCheck -= SomeTree_AfterCheck;
        }
        private void SomeTreeEndUpdate()
        {
            SomeTree.AfterCheck += SomeTree_AfterCheck;
            SomeTree.EndUpdate();
        }
        private void SomeTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SomeTreeBeginUpdate();
            RecursiveCheckNodesDown(e.Node.Nodes, e.Node.Checked);
            if( e.Node.Checked )
                RecursiveCheckNodesUp(e.Node.Parent, e.Node.Checked);
            SomeTreeEndUpdate();
        }
        this.SomeTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.SomeTree_AfterCheck);
