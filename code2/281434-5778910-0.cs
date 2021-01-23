    private void myTreeView_MouseDown(object sender, MouseEventArgs e)
    {
        TreeViewHitTestInfo info = myTreeView.HitTest(e.X, e.Y);
    
        // Ensure that the user actually clicked on a node (there are lots of areas
        // over which they could potentially click that do not contain a node)
        if ((info.Node != null) && (info.Node == myTreeView.SelectedNode))
        {
            // The user clicked on the currently-selected node,
            // so refresh the TreeView
            // . . . 
        }
    }
