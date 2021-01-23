    private bool IsClickOnText(TreeView treeView, TreeNode node, Point location)
    {
    	var hitTest = treeView1.HitTest(location);
    
    	return hitTest.Node == node
    		&& hitTest.Location == TreeViewHitTestLocations.Label;
    }
    
    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
    	if(IsClickOnText(treeView1, e.Node, e.Location))
    	{
    		MessageBox.Show("click");
    	}
    }
    
    private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
    	if (e.Action == TreeViewAction.ByMouse)
    	{
    		var position = treeView1.PointToClient(Cursor.Position);		
    		e.Cancel = !IsClickOnText(treeView1, e.Node, position);
    	}
    }
