    private async void OnTabItemChanged(object sender, SelectionChangedEventArgs e)
    {
        
        TabControl tabControl = sender as TabControl; // e.Source could have been used instead of sender as well
        TabItem item = tabControl.SelectedValue as TabItem;
        if (item.Name == "MainTap")
        {
            Debug.WriteLine(item.Name);
        }
    }
