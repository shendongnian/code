    public delegate TreeView updateLabelDelegate(TreeView view);
    private TreeView InvokeTreeView(TreeView view)
    {
    	if (view.InvokeRequired)
    	{
        	view.Invoke(new updateLabelDelegate(InvokeLabel), new object[] { view });
    		return null;
    	}
    	else
    	{
    		return view;				
    	}
    }
