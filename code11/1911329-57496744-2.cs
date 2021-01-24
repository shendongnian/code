    private void TreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
    	Debug.WriteLine("TreeView1_AfterLabelEdit");
    }
    
    private void TreeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
    	Debug.WriteLine("TreeView1_BeforeLabelEdit");
    }
    
    private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
    	e.Node.BeginEdit();
    }
