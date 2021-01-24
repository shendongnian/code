    private void ListboxButtonUp_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ICollectionViewModel icollvm)
        {
            icollvm.MoveUp();
        }
    }
