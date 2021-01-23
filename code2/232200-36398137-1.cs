    void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    if (e.NewItems != null)
    {
        foreach(Item newItem in e.NewItems)
        {
            ModifiedItems.Add(newItem);
            //Add listener for each item on PropertyChanged event
            if (e.Action == NotifyCollectionChangedAction.Add)
                newItem.PropertyChanged += this.ListTagInfo_PropertyChanged;
            else if (e.Action == NotifyCollectionChangedAction.Remove)
                newItem.PropertyChanged -= this.ListTagInfo_PropertyChanged;
        }
    }
    // MSDN: OldItems:Gets the list of items affected by a Replace, Remove, or Move action.  
    //if (e.OldItems != null) <--- removed
    }
