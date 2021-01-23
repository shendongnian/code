	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		var item = sender as MenuItem;
		while (item.Parent is MenuItem)
		{
			item = (MenuItem)item.Parent;
		}
		var menu = item.Parent as ContextMenu;
		if (menu != null)
		{
			var droidsYouAmLookingFor = menu.PlacementTarget as TextBox;
			//...
		}
	}
