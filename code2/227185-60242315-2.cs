    internal class CustomDataGridView : DataGridView
    {
        public SortOrder MySortOrder { get; set; }
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            BindingSource MyBindingSource = (BindingSource)base.DataSource;
            switch (MySortOrder)
            {
                case SortOrder.None:
                    MyBindingSource.Sort = base.Columns[e.ColumnIndex].Name + " ASC";
                    MySortOrder = SortOrder.Ascending;
                    break;
                case SortOrder.Ascending:
                    MyBindingSource.Sort = base.Columns[e.ColumnIndex].Name + " DESC";
                    MySortOrder = SortOrder.Descending;
                    break;
                case SortOrder.Descending:
                    MyBindingSource.RemoveSort();
                    MySortOrder = SortOrder.None;
                    break;
            }
            base.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = MySortOrder; //mini arrow
        }
    }
