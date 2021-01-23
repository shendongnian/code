    public class UpdateSourceOnPasswordChangedBehavior
		 : Behavior<PasswordBox>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			AssociatedObject.PasswordChanged += OnPasswordChanged;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			AssociatedObject.PasswordChanged -= OnPasswordChanged;
		}
		private void OnPasswordChanged(object sender, RoutedEventArgs e)
		{
			AssociatedObject.GetBindingExpression(PasswordBox.PasswordProperty).UpdateSource();
		}
	}
