            bool _allowNodeRenaming;
    
            private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
            {
                if (!_allowNodeRenaming)
                {
                    e.CancelEdit = true;
                }
    
                _allowNodeRenaming = false;
            }
    
            private void treeView1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F2)
                {
                    _allowNodeRenaming = true;
                    treeView1.SelectedNode.BeginEdit();
                }
            }
