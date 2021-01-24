    // Selected Item
    //
    private string _Colors_SelectedItem { get; set; }
    public string Colors_SelectedItem
    {
        get { return _Colors_SelectedItem; }
        set
        {
            var previousItem = _Colors_SelectedItem;
            _Colors_SelectedItem = value;
            OnPropertyChanged("Colors_SelectedItem");
    
            // Ignore if Previous Item is different than New Item
            if (previousItem != value)
            {
                // Moved the code I want to run in here
                // I want to ignore the code in here when the SelectionChanged Event fires 
                // and the Previous and Newly Selected Items are the same
            }
    
        }
    }
