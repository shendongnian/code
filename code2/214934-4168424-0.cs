        private void UpdateSelectedItem(object sender, SelectionChangedEventArgs e)
        {
            // Ignore if there is no selection
            if (DecksListBox.SelectedIndex == -1)
                return;
            App.ViewModel.MySelectedItem = App.ViewModel.MyItemsList[DecksListBox.SelectedIndex];
        }
