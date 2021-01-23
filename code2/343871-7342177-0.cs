    int MyPreferedTabPageIndex = 1; // ?
    
    private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Helper.GetProperty<bool>("IsTabLocked")) // my condition
            {
                MainTabControl.SelectedIndex = MyPreferedTabPageIndex ;
                MessageBox.Show("tab is locked");
                
            }
        }
