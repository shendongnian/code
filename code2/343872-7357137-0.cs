        static int TabControlIndex = 0;
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.Source is TabControl))
                return;
            if (TabControlIndex == MainTabControl.SelectedIndex)
                return;
            if (Helper.GetProperty<bool>("IsTabLocked") && TabControlIndex != MainTabControl.SelectedIndex)
            {
                MessageBox.Show("locked");
                MainTabControl.SelectedIndex = TabControlIndex;
                // = true;
                return;
            }
