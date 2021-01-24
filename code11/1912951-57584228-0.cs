    private void AButton_Click(object sender, RoutedEventArgs e)
    {
        // You are changing your Items' reference completely here, the XAML binding 
        // in your View is still bound to the old reference, that is why you're seeing nothing.
        //MainWindow.ViewModel.Instance.Items = Search(searchParam);
        
        var searchResults = Search(searchParam);
        foreach(var searchResult in searchResults)
        {
            MainWindow.ViewModel.Instance.Items.Add(searchResult);
        }
    }
