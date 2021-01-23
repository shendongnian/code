    public class ClearFocusOnOutsideClickBehavior : Behavior<FrameworkElement>
    	{
    		protected override void OnAttached()
    		{
    
    			AssociatedObject.GotFocus += AssociatedObjectOnGotFocus;
                base.OnAttached();
    		}
    
    		private void AssociatedObjectOnGotFocus(object sender, RoutedEventArgs e)
    		{
    			App.Current.MainWindow.MouseUp += _paren_PreviewMouseUp;
                AssociatedObject.MouseUp += _paren_PreviewMouseUp;
            }
    
            private void _paren_PreviewMouseUp(object sender, MouseButtonEventArgs e)
            {
    			if(!(sender is TextBox))
    				Keyboard.ClearFocus();
            }
    
    		protected override void OnDetaching()
    		{
    
    		    App.Current.MainWindow.MouseUp -= _paren_PreviewMouseUp;
    			AssociatedObject.MouseUp -= _paren_PreviewMouseUp;
            }
    	}
