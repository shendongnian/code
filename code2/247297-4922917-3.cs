		public static readonly DependencyProperty ShouldHandleNavigatedProperty =
			DependencyProperty.RegisterAttached(
				"ShouldHandleNavigated", 
				typeof(Boolean), 
				typeof(WebBrowserUtility), 
				new UIPropertyMetadata(false, ShouldHandleNavigatedPropertyChanged));
		public static Boolean GetShouldHandleNavigated(DependencyObject obj)
		{
			return (Boolean)obj.GetValue(BindableSourceProperty);
		}
		public static void SetShouldHandleNavigated(DependencyObject obj, Boolean value)
		{
			obj.SetValue(ShouldHandleNavigatedProperty, value);
		}
		public static void ShouldHandleNavigatedPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			WebBrowser browser = o as WebBrowser;
			if (browser != null)
			{
				if ((bool)e.NewValue)
				{
					browser.Navigated += new NavigatedEventHandler(Browser_Navigated);
				}
				else
				{
					browser.Navigated -= new NavigatedEventHandler(Browser_Navigated);
				}
			}
		}
		private static void Browser_Navigated(object sender, NavigationEventArgs e)
		{
			WebBrowser browser = sender as WebBrowser;
			if (browser != null)
			{
				browser.SetValue(WebBrowserUtility.BindableSourceProperty, browser.Source.AbsoluteUri);
			}
		}
