    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
    	if( e.ToolStrip.GetType().Name != "MyCustomToolStrip" )
    	{
    		base.OnRenderToolStripBorder(e);
    	}
    }
