	int _clickCount = 0;
	private void RepeatButton_Click(object sender, RoutedEventArgs e)
	{
		if (_clickCount > 0)
		{
			// Repeated hold action
		}
		_clickCount++;
	}
	private void RepeatButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		if (_clickCount == 1)
		{
			// Short click action
		}
		_clickCount = 0;
	}
