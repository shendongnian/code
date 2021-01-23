    // Implement an "autoscroll" routine for drag
    //  and drop. If the drag cursor moves to the bottom
    //  or top of the treeview, call the Windows API
    //  SendMessage function to scroll up or down automatically.
    private void DragScroll (
        object sender,
        DragEventArgs e)
    {
        // Set a constant to define the autoscroll region
        const Single scrollRegion = 20;
       
        // See where the cursor is
        Point pt =  TreeView1.PointToClient(Cursor.Position);
       
        // See if we need to scroll up or down
        if ((pt.Y + scrollRegion) > TreeView1.Height)
        {
            // Call the API to scroll down
            SendMessage(TreeView1.Handle, (int)277, (int)1, 0);
        }
        else if (pt.Y < (TreeView1.Top + scrollRegion))
        {
            // Call thje API to scroll up
            SendMessage(TreeView1.Handle, (int)277, (int)0, 0);
    }
