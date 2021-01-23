    public static class DatatGridViewExtensions
    {
        public static void SetColumnSortMode(this DataGridView dataGridView, DataGridViewColumnSortMode sortMode)
        {
            foreach (var column in dataGridView.Columns)
            {
                column.SortMode = sortMode;
            }
        }
    }
