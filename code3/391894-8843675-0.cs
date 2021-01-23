     private bool handleSelection=true;
    private void ComboBox_SelectionChanged(object sender,
                                            SelectionChangedEventArgs e)
            {
                if (handleSelection)
                {
                    MessageBoxResult result = MessageBox.Show
                            ("Continue change?", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        ComboBox combo = (ComboBox)sender;
                        handleSelection = false;
                        combo.SelectedItem = e.RemovedItems[0];
                        return;
                    }
                }
                handleSelection = true;
            }
