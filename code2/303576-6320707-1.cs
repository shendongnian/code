    private void cmdPrevious_Click(object sender, RoutedEventArgs e)
    {
        Person[] peoples = this.FindResource("myPeoples") as Person[];
        System.ComponentModel.ICollectionView collectionView = CollectionViewSource.GetDefaultView(peoples);
        collectionView.MoveCurrentToPrevious();
    }
    private void cmdNext_Click(object sender, RoutedEventArgs e)
    {
        Person[] peoples = this.FindResource("myPeoples") as Person[];
        System.ComponentModel.ICollectionView collectionView = CollectionViewSource.GetDefaultView(peoples);
        collectionView.MoveCurrentToNext();
    }
