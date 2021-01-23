    public static readonly DependencyProperty TextProperty =
    	TextBox.TextProperty.AddOwner(typeof(MyControl));
    public string Text
    {
    	get { return (string)GetValue(TextProperty); }
    	set { SetValue(TextProperty, value); }
    }
