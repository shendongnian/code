    class MyFlowLayoutPanel : FlowLayoutPanel
    {
    	const int WM_NCMOUSEMOVE = 0x00A0;
    
    	protected override void WndProc(ref Message m)
    	{
    		if( m.Msg == WM_NCMOUSEMOVE )
    		{
    			Console.WriteLine("MouseOverScrollbar");
    		}
    
    		base.WndProc(ref m);
    	}
    }
