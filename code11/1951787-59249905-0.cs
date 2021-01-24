    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        DG.Columns[0].HeaderTemplate = (DataTemplate)FindResource("myHeaderTemplate");
        DG.Dispatcher.BeginInvoke(new Action(() =>
        {
            DataGridColumnHeadersPresenter presenter = FindVisualChild<DataGridColumnHeadersPresenter>(DG);
            DataGridCellsPanel dataGridCellsPanel = FindVisualChild<DataGridCellsPanel>(presenter);
            DataGridColumnHeader header = dataGridCellsPanel.Children[0] as DataGridColumnHeader;
            Button button = FindVisualChild<Button>(header);
            if (button != null)
                button.Click += MyButton_Click;
        }));
    }
    private void MyButton_Click(object sender, RoutedEventArgs e)
    {
        //DO SOMETHING
    }
    private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
            if (child != null && child is T)
                return (T)child;
            else
            {
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
        }
        return null;
    }
