    private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
    	if (e.Action == TreeViewAction.ByMouse)
    	{
    		var position = treeView1.PointToClient(Cursor.Position);
    		var hitTest = treeView1.HitTest(position);
    
    		e.Cancel = hitTest.Node == e.Node && hitTest.Location != TreeViewHitTestLocations.Label;
    	}
    }
