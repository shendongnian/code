    public void FixListboxFocus()
    {
        if (lbFiles.SelectedItem != null)
        {
            lbFiles.ScrollIntoView(lbFiles.SelectedItem);
            lbFiles.UpdateLayout();
            var item = lbFiles.ItemContainerGenerator.ContainerFromItem(viewModel.SelectedFile);
            if (item != null && item is ListBoxItem listBoxItem && !listBoxItem.IsFocused)
                listBoxItem.Focus();
        }
    }
