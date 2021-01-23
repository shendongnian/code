	public static class BindableToolTip
	{
		public static readonly DependencyProperty ToolTipProperty = DependencyProperty.RegisterAttached(
			"ToolTip", typeof(FrameworkElement), typeof(BindableToolTip), new PropertyMetadata(null, OnToolTipChanged));
		public static void SetToolTip(DependencyObject element, FrameworkElement value) { element.SetValue(ToolTipProperty, value); }
		public static FrameworkElement GetToolTip(DependencyObject element) { return (FrameworkElement)element.GetValue(ToolTipProperty); }
		static void OnToolTipChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			ToolTipService.SetToolTip(element, e.NewValue);
			if (e.NewValue != null)
			{
				((ToolTip)e.NewValue).DataContext = GetDataContext(element);
			}
		}
		public static readonly DependencyProperty DataContextProperty = DependencyProperty.RegisterAttached(
			"DataContext", typeof(object), typeof(BindableToolTip), new PropertyMetadata(null, OnDataContextChanged));
		public static void SetDataContext(DependencyObject element, object value) { element.SetValue(DataContextProperty, value); }
		public static object GetDataContext(DependencyObject element) { return element.GetValue(DataContextProperty); }
		static void OnDataContextChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			var toolTip = GetToolTip(element);
			if (toolTip != null)
			{
				toolTip.DataContext = e.NewValue;
			}
		}
	}
