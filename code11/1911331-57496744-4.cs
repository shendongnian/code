    private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (!e.Node.IsSelected)
        	e.Node.BeginEdit();
    }
