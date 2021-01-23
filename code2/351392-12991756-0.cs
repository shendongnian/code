    public void cmbYourComboBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
        ICollectionView filteredView = CollectionViewSource.GetDefaultView(collection);
        
        filteredView.Filter = new Predicate<object>(GetFilteredView);
        
        dgYourDataGrid.ItemsSource = filteredView;
    }
    public bool GetFilteredView(object sourceObject)
    {
        if (HasConditionOne(sourceObject) && HasConditionTwo(sourceObject)
        {
            return true;
        }
        return false;
    }
    public bool HasConditionOne(object sourceObject)
    {
        //perform your test and evaluate the outcome
    }
    public bool HasConditionTwo(object sourceObject)
    {
        //perform your test and evaluate the outcome
    }
