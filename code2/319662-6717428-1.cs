	for (int i = 0; i < ictest.Items.Count; i++)
	{
		var container = ictest.ItemContainerGenerator.ContainerFromIndex(i) as ContentPresenter;
		var button = container.ContentTemplate.FindName("buton", container) as Button;
		if (button.Content == "Skeet")
		{
			button.Background = Brushes.Red;
		}
	}
