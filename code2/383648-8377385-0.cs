    private List<Control> _scalingControls;
    public List<Control> ScalingControls
    {
    	get
    	{
    		if (_scalingControls == null) {
    			_scalingControls = new List<Control>();
    			foreach (Control c in frm.Controls) {
    				if ((string)c.Tag == "scaling") {
    					_scalingControls.Add(c);
    				}
    			}
    		}
    		return _scalingControls;
    	}
    }
