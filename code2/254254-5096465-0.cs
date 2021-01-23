    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    
        _textBox = (TextBox)base.GetTemplateChild("TextBox");
    }
    
    public new void Focus()
    {
    	if (_textBox == null)
    		base.Focus();
    	else
    		_textBox.Focus();
    }
    
    private TextBox _textBox;
