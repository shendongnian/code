	private static readonly DependencyPropertyKey IsButtonMouseOverPropertyKey = DependencyProperty.RegisterReadOnly("IsButtonMouseOver",
		typeof(bool), typeof(ToolbarButtonCombo), new FrameworkPropertyMetadata(false));
	public static readonly DependencyProperty IsButtonMouseOverProperty = ToolbarButtonCombo.IsButtonMouseOverPropertyKey.DependencyProperty;
	public bool IsButtonMouseOver {
		get { return (bool)this.GetValue(IsButtonMouseOverProperty); }
		private set { this.SetValue(IsButtonMouseOverPropertyKey, value); }
	}
