    private void button_Click(object sender, RoutedEventArgs e)
    {
        DataGridRow dataGridRow = dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex) as DataGridRow;
        if (dataGridRow != null)
        {
            dataGridRow.Background = Brushes.Green;
        }
    }
