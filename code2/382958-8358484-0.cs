    TreeView ConvertTreeNodeToTreeView(TreeNode tn) {
            TreeView tv = new TreeView();
            tv.Nodes.Add(tn);
            return tv;
        }
    
        protected void tv_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.tv.SelectedNode != null) {
                this.Panel1.Controls.Add(ConvertTreeNodeToTreeView(tv.SelectedNode));
            }
        }
