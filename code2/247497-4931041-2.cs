    	private void Invalidate(object sender, RoutedEventArgs e)
		{
			_payload.Timestamp = DateTime.Now.Add(TimeSpan.FromHours(1)).ToLongTimeString();
			Button b = sender as Button;
			BindingExpression be = b.GetBindingExpression(Button.ContentProperty);
			be.UpdateTarget();
		}
