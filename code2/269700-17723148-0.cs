        private void tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetChildrenChecked(e.Node);
            }
        }
        private void SetChildrenChecked(TreeNode treeNode)
        {
            foreach (TreeNode item in treeNode.Nodes)
            {
                if (item.Checked != treeNode.Checked)
                {
                    item.Checked = treeNode.Checked;
                }
                if (item.Nodes.Count > 0)
                {
                    SetChildrenChecked(item);
                }                
            }
        }
