    static class DataGridColumnWidthExtensions
    {
        public static DataGridTableStyle GetCurrentTableStyle(this DataGrid grid)
        {
            FieldInfo[] fields = grid.GetType().GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);
            return (DataGridTableStyle)fields.First(item => item.Name == "myGridTable").GetValue(grid);
        }
        public static IList<int> GetColumnWidths(this DataGrid grid)
        {
            var styles = grid.GetCurrentTableStyle().GridColumnStyles;
            var widths = new int[styles.Count];
            for (int ii = 0; ii < widths.Length; ii++)
            {
                widths[ii] = styles[ii].Width;
            }
            return widths;
        }
        public static void SetColumnWidths(this DataGrid grid, IList<int> widths)
        {
            var styles = grid.GetCurrentTableStyle().GridColumnStyles;
            for (int ii = 0; ii < widths.Count; ii++)
            {
                styles[ii].Width = widths[ii];
            }
        }
    }
