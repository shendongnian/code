	using System.Windows.Controls.Primitives;       // Contains TabPanel
	using LinqToVisualTree;
	
	void AddPlusButton() {
		// Creates a button beside the tabs
		var button = new Button()
		{
			Content = "+",
			IsTabStop = false      // To prevent keyboard press
		};
		// Links the Click with the "new tab" function
		button.Click += new RoutedEventHandler(btPlus_Click);
		// *** HERE IS THE TRICK ***
		// Gets the parent TabPanel in the Visual Tree and cast it
		var tabpn = tabItem1.Ancestors<TabPanel>().FirstOrDefault() as TabPanel;
		
		// Links the button created
		tabpn.Children.Add(button);
	}
