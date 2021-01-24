    void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
    {
        ListView listView = sender as ListView;
        ICollectionView view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
        //...
    }
