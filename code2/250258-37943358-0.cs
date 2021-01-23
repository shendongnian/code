     private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            foreach (var column in dg.Columns)
            {
                column.Width = new DataGridLength(dg.ActualWidth / dg.Columns.Count, DataGridLengthUnitType.Pixel);
            }
        }
