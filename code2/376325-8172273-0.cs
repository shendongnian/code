    <ListView SelectionChanged="AccountListView_SelectionChanged" ... />
    private void AccountListView_SelectionChanged(Object sender, SelectionChangedEventArgs args)
    {
        DebitButton.IsEnabled = (sender != null);
        //etc ...
    }
