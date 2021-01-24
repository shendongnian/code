    public partial class MainWindow : Window
    {
      private void HideRow_OnButtonClicked(object sender, RoutedEventArgs e)
      {
        // Use the extension method to traverse the visual tree to search for the parent row
        if ((sender as DependencyObject).TryFindVisualParentElement(out DataGridRow dataGridRow))
        {
          dataGridRow.Visibility = Visibility.Collapsed;
        }
      }
    
      private void ShowAllRows_OnButtonClicked(object sender, RoutedEventArgs e)
      {
        foreach (object rowData in this.MyDataGrid.Items)
        {
          (this.MyDataGrid.ItemContainerGenerator.ContainerFromItem(rowData) as FrameworkElement).Visibility =
            Visibility.Visible;
        }
      }
    }
