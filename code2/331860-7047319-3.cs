    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        DataGrid dataGrid = sender as DataGrid;
        List<DataGridRow> generatedDataGridRows = VisualTreeHelpers.GetVisualChildCollection<DataGridRow>(dataGrid);
        MessageBox.Show(generatedDataGridRows.Count.ToString());
    }
    public static List<T> GetVisualChildCollection<T>(object parent) where T : Visual
    {
        List<T> visualCollection = new List<T>();
        GetVisualChildCollection(parent as DependencyObject, visualCollection);
        return visualCollection;
    }
    private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : Visual
    {
        int count = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < count; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);
            if (child is T)
            {
                visualCollection.Add(child as T);
            }
            else if (child != null)
            {
                GetVisualChildCollection(child, visualCollection);
            }
        }
    }
