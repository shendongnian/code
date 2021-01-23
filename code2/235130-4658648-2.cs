    private void on_selection(object sender, SelectionChangedEventArgs e)
    {
        // As the listbox is named we can do this:
        if (Index_list.SelectedIndex >= 0)
        {
            MessageBox.Show((Index_list.SelectedItem as TextBlock).Text);
        }
        // if the listbox wasn't named we could do this:
        if (sender is ListBox) // always good to double check
        {
            var sal = sender as ListBox;
            if (sal.SelectedIndex >= 0)
            {
                MessageBox.Show((sal.SelectedItem as TextBlock).Text);
            }
        }
        // Or we could use the EventArgs:
        if (e.AddedItems.Count == 1)
        {
            MessageBox.Show((e.AddedItems[0] as TextBlock).Text);
        }
    }
