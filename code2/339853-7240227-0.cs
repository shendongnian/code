    private void treeView_MouseDown(object sender, MouseEventArgs e)
    {
        //See what node is at the location that was just clicked
        var clickedNode = treeView.GetNodeAt(e.Location);
        //Make that node the selected node
        treeView.SelectedNode = clickedNode;
    }
    private void function_name(object sender, EventArgs e)
    {
        var currentNode = treeView.SelectedNode;
        //Do something with currentNode
    }
