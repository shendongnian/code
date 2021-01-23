	public static readonly DependencyProperty CurrentItemProperty =
		DependencyProperty.Register
		(
			"CurrentItem",
			typeof(object),
			typeof(ListBoxViewModel),
			new UIPropertyMetadata(null, CurrentItemChanged)
		);
	public object CurrentItem
	{
		get { return (object)GetValue(CurrentItemProperty); }
		set { SetValue(CurrentItemProperty, value); }
	}
	private static void CurrentItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		// Update current item logic
	}
