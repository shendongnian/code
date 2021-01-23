    <TabControl SelectionChanged="OnSelectionChanged" ... />
    private void OnSelectionChanged(Object sender, SelectionChangedEventArgs args)
    {
        var tc = sender as TabControl; //The sender is a type of TabControl...
        if (tc != null)
        {
            var item = tc.SelectedItem;
            //Do Stuff ...
        }
    }
