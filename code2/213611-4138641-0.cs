    private void btnViewItem_Click(object sender, RoutedEventArgs e)
    {
        StockObject s = lvwInventory.SelectedItem;
        if (s != null)
            bookDialog.View(s);
    }
?
