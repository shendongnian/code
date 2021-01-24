    List<row> list = new List<row>();
    private void clear_Click(object sender, RoutedEventArgs e)
    {
        //...
        list.Clear();
        //...
    }
    private void button_Click(object sender, RoutedEventArgs e)
    {
        //...
        newRow.eps = 1;
        list.Add(newRow);
        dataGrid.ItemsSource = list;
    }
