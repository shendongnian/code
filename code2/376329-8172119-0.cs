    <TabControl SelectionChanged="OnSelectionChanged" ... />
    private void OnSelectionChanged(Object sender, SelectionChangedEventArgs args)
    {
        TabItem item = sender as TabItem; //The sender is a type of TabItem...
        if (item != null)
        {
            //Do Stuff ...
        }
    }
