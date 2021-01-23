    private void button1_Click(object sender, RoutedEventArgs e)
    {
        if (lbChoices.SelectedItem != null)
        {
            ListBoxItem selectedItem = (ListBoxItem)lbChoices.SelectedItem; 
            int selectedIndex = lbChoices.SelectedIndex;
            if (lbChoices.Items.Count > 1)
            {
                if (selectedIndex > 0)
                {
                    lbChoices.Items.Remove(lbChoices.SelectedItem);
                    lbChoices.Items.Insert(selectedIndex - 1, selectedItem);
                }
            }
        }
    }
