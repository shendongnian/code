    private void grid_AfterColPosChanged(object sender, AfterColPosChangedEventArgs e)
    {
        foreach (UltraGridBand band in grid.DisplayLayout.Bands)
        {
           foreach (ColumnFilter filter in band.ColumnFilters)
           {
                if (filter.Column.Hidden)
                {
                    filter.ClearFilterConditions();
                }
           }
       }
    {
