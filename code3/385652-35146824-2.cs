    private static void EnsureVisibleRow(DataGridView view, int rowToShow)
    {
        if (rowToShow >= 0 && rowToShow < view.RowCount)
        {
            var countVisible = view.DisplayedRowCount(false);
            var firstVisible = view.FirstDisplayedScrollingRowIndex;
            if (rowToShow < firstVisible)
            {
                view.FirstDisplayedScrollingRowIndex = rowToShow;
            }
            else if (rowToShow >= firstVisible + countVisible)
            {
                view.FirstDisplayedScrollingRowIndex = rowToShow - countVisible + 1;
            }
        }
    }
