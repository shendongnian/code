    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        DataGridRow newItemPlaceholderRow = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(CollectionView.NewItemPlaceholder);
        if (newItemPlaceholderRow != null)
            newItemPlaceholderRow.GotFocus += (ss, ee) =>
            {
                typeof(DataGrid).GetMethod("AddNewItem",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .Invoke(dg, null);
            };
    }
