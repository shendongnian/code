    long SB_HORZ = 0;
    long SB_VERT = 1;
    long SB_BOTH = 3;
    
    private static void SetScrollBarVisible (Control control, long sb, bool enable)
    {
    	if (control != null) return;
    	if (enable)
    		ShowScrollBar(control.Handle.ToInt64(), sb, 1);
    	else
    		ShowScrollBar(control.Handle.ToInt64(), sb, 0);
    }
