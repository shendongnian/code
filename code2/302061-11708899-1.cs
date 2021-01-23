    private static void HandleDoubleClick(object sender, MouseButtonEventArgs e)
    {
    	if (e.ClickCount == 2)
    	{
    		Control control = (Control)sender;
    		MouseButtonEventArgs mouseButtonEventArgs = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice);
    		if (e.RoutedEvent == UIElement.PreviewMouseLeftButtonDownEvent || e.RoutedEvent == UIElement.PreviewMouseRightButtonDownEvent)
    		{
    			mouseButtonEventArgs.RoutedEvent = Control.PreviewMouseDoubleClickEvent;
    			mouseButtonEventArgs.Source = e.OriginalSource;
    			mouseButtonEventArgs.OverrideSource(e.Source);
    			control.OnPreviewMouseDoubleClick(mouseButtonEventArgs);
    		}
    		else
    		{
    			mouseButtonEventArgs.RoutedEvent = Control.MouseDoubleClickEvent;
    			mouseButtonEventArgs.Source = e.OriginalSource;
    			mouseButtonEventArgs.OverrideSource(e.Source);
    			control.OnMouseDoubleClick(mouseButtonEventArgs);
    		}
    		if (mouseButtonEventArgs.Handled)
    		{
    			e.Handled = true;
    		}
    	}
    }
