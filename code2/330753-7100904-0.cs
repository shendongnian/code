    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        ItemsListBox.ItemsSource = null;
        Array.Sort(items, delegate(string first, string second)
        {
            return DateTime.Compare(Convert.ToDateTime(first), Convert.ToDateTime(second));
        });
        ItemsListBox.ItemsSource = items;
    }
