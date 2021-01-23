    public static readonly DependencyProperty IsEditingProperty =
    		DependencyProperty.Register("IsEditing", typeof(Boolean), typeof(MyDetailDataControl), new UIPropertyMetadata(false));
    // This:
    public Boolean IsEditing
    {
    	get { return (Boolean)GetValue(IsEditingProperty); }
    	set { SetValue(IsEditingProperty, value); }
    }
