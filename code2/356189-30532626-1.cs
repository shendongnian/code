           bool manualcheck = false;
          protected override void OnAfterCheck(TreeViewEventArgs e)
          {
                    if (manualcheck) return;
                    if (e.Node.Checked)
                    {
                       if (Nodes.Count>0) UnCheckAll(Nodes[0]);
                       manualcheck = true;
                    e.Node.Checked = true;
                    manualcheck = false;
                    }
                    
                   
            }
        
        
            void UnCheckAll(TreeNode node)
                {
        
               
                    if (node != null)
                    {
        
                        node.Checked = false;
                        foreach (TreeNode item in node.Nodes)
                        {
                            manualcheck = true;
                            item.Checked = false;
                            if (item.Nodes.Count > 0) UnCheckAll(item.Nodes[0]);
                        }
        
        
                        if (node.NextNode != null)
                            UnCheckAll(node.NextNode);
        
                    }
                    manualcheck = false;
                }
