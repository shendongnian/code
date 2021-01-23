        public static class AutoScrollHelper
    	{
    		public static readonly DependencyProperty AutoScrollProperty =
    			DependencyProperty.RegisterAttached("AutoScroll", typeof(bool), typeof(AutoScrollHelper), new PropertyMetadata(false, AutoScrollPropertyChanged));
    
    
    		public static void AutoScrollPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    		{
    			var scrollViewer = obj as ScrollViewer;
    			if (scrollViewer == null) return;
    
    			if ((bool) args.NewValue)
    			{
    				scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
    				scrollViewer.ScrollToEnd();
    			}
    			else
    			{
    				scrollViewer.ScrollChanged -= ScrollViewer_ScrollChanged;
    			}
    		}
    
    		static void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
    		{
    			if (e.ExtentHeightChange > 0 || e.ViewportHeightChange > 0)
    			{
    				var scrollViewer = sender as ScrollViewer;
    				scrollViewer?.ScrollToEnd();
    			}
    		}
    
    		public static bool GetAutoScroll(DependencyObject obj)
    		{
    			return (bool) obj.GetValue(AutoScrollProperty);
    		}
    
    		public static void SetAutoScroll(DependencyObject obj, bool value)
    		{
    			obj.SetValue(AutoScrollProperty, value);
    		}
    	}
