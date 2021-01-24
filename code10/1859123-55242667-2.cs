    public bool UpdateOnPropChanged
    {
    	get
    	{
    		return _updateOnPropChanged;
    	}
    	set
    	{
    		_updateOnPropChanged = value;
    		this.TextBox.SetBinding(TextBox.TextProperty, new Binding("Text") { RelativeSource=new RelativeSource(RelativeSourceMode.FindAncestor) { AncestorType=typeof(LabelWithTextBox) }, UpdateSourceTrigger = _updateOnPropChanged ? UpdateSourceTrigger.PropertyChanged : UpdateSourceTrigger.LostFocus });
    	}
    }
    private bool _updateOnPropChanged;
