    void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var itemsControl = listBox;
        var sibling = item1;
        var nextSibling = GetNextSibling(itemsControl, sibling) as ListBoxItem;
        MessageBox.Show(string.Format("Sibling is {0}", nextSibling.Content));
    }
