    ContentControl _active;
    private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    
    	if (_active == Content1)
    	{
    		_active = Content2;
    		Content2Active.Begin();
    	} else
    	{
    		_active = Content1;
    		Content1Active.Begin();
    	}
    
    	_active.Content = LB.SelectedItem;
    }
