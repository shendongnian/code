    private void tabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.OriginalSource == tabControl)
            {
                if (EditMode == TEditMode.emBrowse)
                {
                    _TabItemIndex = tabControl.SelectedIndex;
                }
                else if (tabControl.SelectedIndex != _TabItemIndex) 
                {
                    e.Handled = true;
                    tabControl.SelectedIndex = _TabItemIndex;
                    MessageBox.Show("Please Save or Cancel your work first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
