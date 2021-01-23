    private Control         _anchorControl;
    private List<Control>   _parentChain = new List<Control>();
    private void BuildChain()
    {
        foreach(var item in _parentChain)
        {
            item.LocationChanged -= ControlLocationChanged;
            item.ParentChanged -= ControlParentChanged;
        }
    
        var current = _anchorControl;
    
        while( current != null )
        {
            _parentChain.Add(current);
            current = current.Parent;
        }
    
        foreach(var item in _parentChain)
        {
            item.LocationChanged += ControlLocationChanged;
            item.ParentChanged += ControlParentChanged;
        }
    }
    
    void ControlParentChanged(object sender, EventArgs e)
    {
        BuildChain();
        ControlLocationChanged(sender, e);
    }
    
    void ControlLocationChanged(object sender, EventArgs e)
    {
        // Update Location of Form
        if( _anchorControl.Parent != null )
        {
            var screenLoc = _anchorControl.Parent.PointToScreen(_anchorControl.Location);
            UpdateFormLocation(screenLoc);
        }
    }
