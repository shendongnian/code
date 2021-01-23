	void btPlus_Click(object sender, RoutedEventArgs e)
	{
		// Creates a new TabItem
		var ti = new TabItem();
		ti.Header = "TabAdded";
		ti.Content = new TextBlock() { Text = "Tab content!" };
		// Links it
		tabControl.Items.Add(ti);
	}
