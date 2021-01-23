        private void grid_AfterColPosChanged(object sender, AfterColPosChangedEventArgs e)
        {
            foreach (UltraGridBand band in grid.DisplayLayout.Bands)
            {
                foreach (ColumnFilter columnFilter in band.ColumnFilters)
                {
                    if (columnFilter.Column.Hidden)
                    {
                        columnFilter.ClearFilterConditions();
                    }
                }
            }
        {
