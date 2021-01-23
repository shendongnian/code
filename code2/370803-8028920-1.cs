    private void Random_Click(object sender, RoutedEventArgs e)
    {
        var count = CollectionView.Count;
        var random = new System.Random();
        var index = random.next(0, count);
        CollectionViewSource.View.MoveCurrentToPosition(index);
    }
