    private async Task Start()
	{			
		for (int i = 0; i < MaxRow; i++)
		{
			for (int j = 0; j < MaxCol; j++)
			{
				string current = $"ImgR{i}C{j}";
				object currentImg = this.FindName(current);
				if (currentImg?.GetType() == typeof(Image))
				{
					var img = ((Image)currentImg);
					await Task.Delay(TimeSpan.FromMilliseconds(1500));
					Application.Current.Dispatcher.Invoke(() =>
					{
						img.Visibility = Visibility.Visible;
						DoEvents(); // no need to invoke a second time
					});
						
					await Task.Delay(TimeSpan.FromMilliseconds(1500));
					Application.Current.Dispatcher.Invoke(() =>
					{
						img.Visibility = Visibility.Hidden;
						DoEvents(); // no need to invoke a second time
					});
				}
			}
		}
	}
