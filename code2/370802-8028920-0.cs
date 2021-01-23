    private void Random_Click(object sender, RoutedEventArgs e)
    {
        var count = CollectionView.Count;
        var random = new System.Random();
        var index = random.next(0, count - 1);
        CollectionViewSource.View.MoveCurrentToPosition(index);
    }
