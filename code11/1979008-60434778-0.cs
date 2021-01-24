    private void DataGridRow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (dg.SelectedItem != null)
        {
            e.Handled = true;
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(dg, e.GetPosition(dg));
            DataGridCell cell = FindParent<DataGridCell>(hitTestResult.VisualHit);
            if (MessageBox.Show(this, "confirm....?", "caption..:", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                dg.SelectedItem = cell.DataContext;
                cell.Focus();
            }
        }
    }
