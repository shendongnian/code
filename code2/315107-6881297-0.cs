    try this...    
    TreeNode node = tv.SelectedNode;
                        if (tv.SelectedNode.Parent == null)
                        {
                            node.TreeView.LabelEdit = false;
                        }
                        else
                        {
                            node.Text = FieldName.Text;
                            if (node == null) { return; }
                            node.TreeView.LabelEdit = true;
                            node.BeginEdit();
                        }
