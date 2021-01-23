	private void ComboBoxItem_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Tab)
		{
			var cbi = sender as ComboBoxItem;
			var cb = cbi.Parent as ComboBox;
			cb.SelectedItem = cbi;
			e.Handled = true;
			cb.IsDropDownOpen = false;
		}
	}
	private void ComboBox_Loaded(object sender, RoutedEventArgs e)
	{
		var cb = sender as ComboBox;
		foreach (var item in cb.Items)
		{
			(item as ComboBoxItem).KeyDown += ComboBoxItem_KeyDown;
		}
	}
