    	public static class WebViewHardware
    	{
    		public static bool GetIsEnabled(WebView obj)
    		{
    			return (bool)obj.GetValue(IsEnabledProperty);
    		}
    
    		public static void SetIsEnabled(WebView obj, bool value)
    		{
    			obj.SetValue(IsEnabledProperty, value);
    		}
    
    		// Using a DependencyProperty as the backing store for IsEnabled.  This enables animation, styling, binding, etc...
    		public static readonly DependencyProperty IsEnabledProperty =
    			DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(WebViewHardware), new PropertyMetadata(false, OnIsEnabledChanged));
    
    		private static void OnIsEnabledChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
    		{
    			var webView = (WebView)dependencyObject;
    
    			var isEnabled = (bool)args.NewValue;
    
    #if __ANDROID__
    			webView.Loaded += OnLoaded;
    
    			void OnLoaded(object sender, RoutedEventArgs e)
    			{
    				webView.Loaded -= OnLoaded;
    				var layerType = isEnabled ? Android.Views.LayerType.Hardware : Android.Views.LayerType.Software;
    
    				webView.SetLayerType(layerType, null);
    			}
    #endif
    		}
