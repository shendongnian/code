    private void ProcessChange(object sender, RoutedEventArgs e)
    {
        if (lbOriginal.ItemsSource is Orders asOrders)
        {
            lbShowSelected.ItemsSource = null; // Inform control of reset
            lbShowSelected.ItemsSource = asOrders.Where(ord => ord.InProgress)
                                                 .Select(ord => ord.CustomerName)
                                                 .ToList();
        }
    }
