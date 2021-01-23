    public class OuterControl
    {
    	protected override void OnParentChanged(EventArgs e)
    	{
    		if (!this.DesignMode)
    		{
    			Form form = this.FindForm();
    			if (form != null)
    			{
    				form.ResizeBegin += (s, ea) =>innerCnt.Resizing = true;
    				form.ResizeEnd += (s, ea) => innerCnt.Resizing = false;
    			}
    		}
    		base.OnParentChanged(e);
    	}
    }
    
    public class InnerControl
    {
    	private bool resizing = false;
    	
    	public bool Resizing { 
    		get { return resizing; }; 
    		set {
    			resizing = value;
    			if (!resizing) {
    				// Resizing is just finished:
    				// let's do what we need
    			}
    		}
    	}
    	
    	protected override void OnResize(EventArgs e)
    	{
    		if (Resizing)
    		{
    			base.OnResize(e);
    			return;
    		}
    		else
    		{
    			// Perform resizing actions
    		}
    	}
    }
