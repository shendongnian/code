	public MC.LocationRect ViewArea {
		get { return (MC.LocationRect)GetValue(ViewAreaProperty); }
		set { SetValue(ViewAreaProperty, value); }
	}
	public static readonly DependencyProperty ViewAreaProperty = DependencyProperty.Register("ViewArea", typeof(MC.LocationRect),
		typeof(Map), new PropertyMetadata(new MC.LocationRect(), OnViewAreaChanged));
	private static void OnViewAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
		var map = d as Map;
		// Call SetView here
	}
