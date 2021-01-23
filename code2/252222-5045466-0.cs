    OK, create a listview and a treeview.
    
    In my example, the listview is called listView1 and the treeview is called tvMain.
    On the treeview, set AllowDrop to true.
    
    Create an ItemDrag event on the listview:
    
    private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
            {
                listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Copy);
            }
    
    
    
    In this example items from the listview are copied to the 'drop' object.
    Now, create a DragEnter event on the treeview:
    
    private void tvMain_DragEnter(object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Copy;
            }
    
    
    
    This was easy. Now the hard part starts. The following code adds the selected (and dragged) listview items to an existing node (make sure you have at least one node already in your treeview or the example will fail!)
    Create a DragDrop event on the treeview:
    
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
    To change the cursor while dragging, you have to create a GiveFeedback event for the ListView control:
    
    private void listView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
            {
                e.UseDefaultCursors = false;
    
                if (e.Effect == DragDropEffects.Copy)
                {
                    Cursor.Current = new Cursor(@"myfile.ico");
                }
            }
    
    
    
    myfile.ico should be in the same directory as the .exe file.
    
    This is just a simple example. You can extend it any way you like.
    I hope this helps. 
