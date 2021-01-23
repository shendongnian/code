    private void choose_house(object sender, RoutedEventArgs e)
    {
    	var button = sender as Button;
    	if (button != null)
    	{
    		var yourObject = button.DataContext as house;
    		if (yourObject != null)
    		{
    			//do stuff with your button
    		}
    	}
    }
