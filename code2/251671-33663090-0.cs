    protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            dataGrid.Width = e.NewSize.Width - (e.NewSize.Width * .1);
            foreach (var column in dataGrid.Columns)
            {
                column.Width = dataGrid.Width / dataGrid.Columns.Count;
            }
        }
