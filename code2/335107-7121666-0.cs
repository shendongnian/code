    private void Sort(string sortBy, ListSortDirection direction)
    {
        ICollectionView dataView = CollectionViewSource.GetDefaultView(this.ItemsSource);
    
        if (dataView != null)
        {
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription("IsAtTop", ListSortDirection.Ascending));
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }
    }
