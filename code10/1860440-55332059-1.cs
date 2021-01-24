    Titles = new ObservableRangeCollection<Models.Salutation>();
    Titles.CollectionChanged += Titles_CollectionChanged;
    private bool handleEvent = true;
    
    private void Titles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
    	if (e.NewItems != null)
    		foreach (Models.Salutation item in e.NewItems)
    			item.PropertyChanged += Salutation_PropertyChanged;
    
    	if (e.OldItems != null)
    		foreach (Models.Salutation item in e.OldItems)
    			item.PropertyChanged -= Salutation_PropertyChanged;
    }
    
    private void Salutation_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    	if(!handleEvent)
    	{
    		return;
    	}
    
    	if (e.PropertyName == "Selected")
    	{
    		handleEvent = false;
    
    		if (sender is Models.Salutation selectedSalutation)
    		{
    			if (selectedSalutation.Selected)
    			{
    				Reset(sender as Models.Salutation);
    			}
    		}
    
    		handleEvent = true;
    	}
    }
