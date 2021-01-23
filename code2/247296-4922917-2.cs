    	public static class WebBrowserUtility
    	{
            ...
    		private const string _SkipSourceChange = "Skip";
    
    		public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    		{
    			WebBrowser browser = o as WebBrowser;
    			if (browser != null)
    			{
    				string uri = e.NewValue as string;
    				if (!_SkipSourceChange.Equals(uri))
    				{
    					browser.Source = uri != null ? new Uri(uri) : null;
    				}
    			}
    		}
    
    		private static void Browser_Navigated(object sender, NavigationEventArgs e)
    		{
    			WebBrowser browser = sender as WebBrowser;
    			if (browser != null)
    			{
    				if (WebBrowserUtility.GetBindableSource(browser) != e.Uri.ToString())
    				{
        					browser.Tag = _SkipSourceChange;
                            browser.SetValue(WebBrowserUtility.BindableSourceProperty, browser.Source.AbsoluteUri);
        					browser.Tag = null;
    				}
    			}
    		}
        }
