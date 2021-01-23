    private int LastSelectedTab = -1;
    
    void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TabControl tab = sender as TabControl;
        if (this.LastSelectedTab != tab.SelectedIndex)
        {
            this.LastSelectedTab = tab.SelectedIndex;
            // Now do your thing...
        }
    }
