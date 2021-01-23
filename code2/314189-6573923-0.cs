	public class HeaderedSeparator : Control
	{
		public static DependencyProperty HeaderProperty =
			DependencyProperty.Register(
			"Header",
			typeof(string),
			typeof(HeaderedSeparator));
		public string Header
		{
			get { return (string)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}
	}
	
