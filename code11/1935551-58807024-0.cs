        private void TabbedHalconApp_Loaded(Object sender, RoutedEventArgs e)
        {
            TabControl1.BeginInit();
            for (int index = 0; index < this.TabControl1.Items.Count; index++)
            {
                this.TabControl1.SelectedIndex = index;
                this.TabControl1.UpdateLayout();
            }
            // Reset to first tab
            this.TabControl1.SelectedIndex = 0;
            TabControl1.EndInit();
        }
