        DataGridRow visibleDetailRow = null;
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            visibleDetailRow = (DataGridRow)sender;
            visibleDetailRow.DetailsVisibility = visibleDetailRow.DetailsVisibility == Visibility.Collapsed ?
                Visibility.Visible : Visibility.Collapsed;
        }
    
        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            if(visibleDetailRow != null)
                visibleDetailRow.DetailsVisibility = Visibility.Collapsed;
        }
