    private void TreeView_MouseClick(object sender, MouseEventArgs e)
    {
        // Get the node that was clicked
        TreeNode selectedNode = myTreeView.HitTest(e.Location).Node;
        if (selectedNode != null)
        {
            // ...
            // Do something with the selected node here...
        }
    }
