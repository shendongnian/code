	public static readonly DependencyProperty MyPropertyProperty =
		DependencyProperty.RegisterAttached
			(
				"MyProperty",
				typeof(object),
				typeof(ThisStaticWrapperClass),
				new UIPropertyMetadata(null, MyPropertyChanged) // <- This
			);
	public static void MyPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TextBox == false && o is ComboBox == false)
		{
			throw new InvalidOperationException("This property may only be set on TextBoxes and ComboBoxes.");
		}
	}
