    public class ClearFocusOnOutsideClickBehavior : Behavior<FrameworkElement>
	{
		protected override void OnAttached()
		{
			AssociatedObject.GotFocus += AssociatedObjectOnGotFocus;
			AssociatedObject.LostFocus += AssociatedObjectOnLostFocus;
            base.OnAttached();
		}
		private void AssociatedObjectOnLostFocus(object sender, RoutedEventArgs e)
		{
			App.Current.MainWindow.MouseUp -= _paren_PreviewMouseUp;
        }
		private void AssociatedObjectOnGotFocus(object sender, RoutedEventArgs e)
		{
			App.Current.MainWindow.MouseUp += _paren_PreviewMouseUp;
        }
        private void _paren_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }
		protected override void OnDetaching()
		{
			AssociatedObject.GotFocus -= AssociatedObjectOnGotFocus;
			AssociatedObject.LostFocus -= AssociatedObjectOnLostFocus;
        }
	}
