    private void GridCtrl_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (sender != null)
        {
            Grid _grid = sender as Grid;
            int _row = (int)_grid.GetValue(Grid.RowProperty);
            int _column = (int)_grid.GetValue(Grid.ColumnProperty);
            MessageBox.Show(string.Format("Grid clicked at column {0}, row {1}", _column, _row));
        }
    }
