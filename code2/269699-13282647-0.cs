    private void trvMenuList_AfterCheck(object sender, TreeViewEventArgs e)
            {
                SetChildrenChecked(e.Node, e.Node.Checked);
     
            }
    
      private void SetChildrenChecked(TreeNode treeNode, bool checkedState)
            {
                foreach (TreeNode item in treeNode.Nodes)
                {
                    if (item.Checked != checkedState)
                    {
                        item.Checked = checkedState;
                    }
                    SetChildrenChecked(item, item.Checked);
                }
            }
