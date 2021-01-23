	private void Button_Click(object sender, RoutedEventArgs e)
	{
		var match = tabControl.Items.OfType<TabItem>().Where(tab => tab.Header.ToString() == textBox.Text).FirstOrDefault();
		if (match != null) match.IsSelected = true;
	}
