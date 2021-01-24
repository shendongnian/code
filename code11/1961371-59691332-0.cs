    private async void Button_Click(object sender, RoutedEventArgs e)
    {
		try
		{
			Mouse.OverrideCursor = Cursors.Wait;
			await Task.Run(() => LoadWindow());
		}
		finally
		{
			Mouse.OverrideCursor = null;
		}
	}
