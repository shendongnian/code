    private void tvMain_DragDrop(object sender, DragEventArgs e)
            {
                TreeNode n;
    
                if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection", false))
                {
                    Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                    TreeNode dn = ((TreeView)sender).GetNodeAt(pt);
                    ListView.SelectedListViewItemCollection lvi = (ListView.SelectedListViewItemCollection)e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection");
    
                    foreach (ListViewItem item in lvi)
                    {
                        n = new TreeNode(item.Text);
                        n.Tag = item;
    
                        dn.Nodes.Add((TreeNode)n.Clone());
                        dn.Expand();
                        n.Remove();
                    }
                }
            }
