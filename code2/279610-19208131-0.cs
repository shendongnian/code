    private void addTabPage_GotFocus(object sender, RoutedEventArgs e)
        {
            addTabPage(); //method for adding page
            TabControlPages.SelectedIndex = TabControlPages.Items.Count - 1; //select added page
            TabControlPages.Focus(); //change forcus to selected page
        }
