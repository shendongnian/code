    private void CheckBox_Clicked(object sender, RoutedEventArgs e)
    {
        UpdateAllSelected(e.OriginalSource as ToggleButton);
        e.Handled = true;
    }
    private void UpdateAllSelected(ToggleButton checkBox)
    {
        var include = checkBox.IsChecked ?? false;
        tickBoxSelector.ApplyToAllSelected<RowViewModel>(checkBox, p => p.Use = include);
        ViewModel.ProcessUseStateChange();
    }
