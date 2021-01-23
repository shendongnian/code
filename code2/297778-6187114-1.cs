        private void lstFoundedFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IgnoreCheckChangeEvents) return;
            int temp = lstFoundedFiles.SelectedItems.Count;
            IgnoreCheckChangeEvents = true;
            if (temp == lstFoundedFiles.Items.Count)
            {
                chbxAll.IsChecked = true;
            }
            else if (temp == 0)
            {
                chbxAll.IsChecked = false;
            }
            else
            {
                chbxAll.IsChecked = null;
            }
            IgnoreCheckChangeEvents = false;
        }
        private void chbxAll_Checked(object sender, RoutedEventArgs e)
        {
            if (IgnoreCheckChangeEvents) return;
            IgnoreCheckChangeEvents = true;
            lstFoundedFiles.SelectAll();
            
            IgnoreCheckChangeEvents = false;
        }
        private void chbxAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (IgnoreCheckChangeEvents) return;
            IgnoreCheckChangeEvents = true;
            lstFoundedFiles.UnselectAll();
            IgnoreCheckChangeEvents = false;
        }
        private void chbxAll_Indeterminate(object sender, RoutedEventArgs e)
        {
            if (IgnoreCheckChangeEvents) return;
            chbxAll.IsChecked = false;
            IgnoreCheckChangeEvents = true;
            lstFoundedFiles.UnselectAll();
            IgnoreCheckChangeEvents = false;
        }
