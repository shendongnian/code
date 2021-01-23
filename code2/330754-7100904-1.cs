    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        ItemsListBox.ItemsSource = null;
        var arrayOfItems = items.ToArray<string>();
        Array.Sort(arrayOfItems, delegate(string first, string second)
        {
            return DateTime.Compare(Convert.ToDateTime(first), Convert.ToDateTime(second));
        });
        items = new List<string>(arrayOfItems);
        ItemsListBox.ItemsSource = items;
    }
