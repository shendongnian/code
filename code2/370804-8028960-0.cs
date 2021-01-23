	readonly Random _random = new Random();
	private void Random_Click(object sender, RoutedEventArgs e)
	{
		var button = (Button)sender;
		var cvs = (CollectionViewSource)button.Tag;
		var view = cvs.View as CollectionView;
		if (view != null)
		{
			cvs.View.MoveCurrentToPosition(_random.Next(0, view.Count));
		}
	}
