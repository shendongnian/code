    //  List of ComboBoxItems - WORKS
    List<ComboBoxItem> testValues = new List<ComboBoxItem>();
    for (int i = 0; i < 80; i++)
    {
    	testValues.Add(new ComboBoxItem
    	{
    		Content = "Item " + i,
    		Tag = i
    	});
    }
    ComboBoxVehicles.ItemsSource = testValues;
