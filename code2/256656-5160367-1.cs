	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Border border = new Border();
		border.Height = 50;
		border.Width = 50;
		border.BorderBrush = new SolidColorBrush(Colors.Black);
		border.BorderThickness = new Thickness(2);
		border.Child = new TextBlock()
		{
			Text = sp1.Children.Count.ToString(),
			HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
			VerticalAlignment = System.Windows.VerticalAlignment.Center
		};
		sp1.Children.Insert(0, border);
	}
