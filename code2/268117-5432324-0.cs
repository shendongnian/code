    public static DependencyProperty EditorTextProperty = DependencyProperty.Register("ExpressionText", typeof(string), typeof(MyUserControl),
    		  new PropertyMetadata(new PropertyChangedCallback((s, e) =>
    		  { })));
    public string ExpressionText
    {
    	get
    	{
    		return (string)base.GetValue(EditorTextProperty);
    	}
        set
    	{
    		base.SetValue(EditorTextProperty, value);
    	}
    }
