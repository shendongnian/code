    internal class CustomDataGridView : DataGridView
    {   
        public SortOrder MySortOrder { get; set; }
        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            BindingSource MyBindingSource = (BindingSource)base.DataSource;
            DataTable MyDataTable = (DataTable)MyBindingSource.DataSource;
            switch (MySortOrder)
            {
                case SortOrder.None:
                    MyDataTable.DefaultView.Sort = base.Columns[e.ColumnIndex].Name + " ASC";
                    MyDataTable = MyDataTable.DefaultView.ToTable();
                    MyBindingSource.DataSource = MyDataTable;
                    MySortOrder = SortOrder.Ascending;
                    break;
                case SortOrder.Ascending:
                    MyDataTable.DefaultView.Sort = base.Columns[e.ColumnIndex].Name + " DESC";
                    MyDataTable = MyDataTable.DefaultView.ToTable();
                    MyBindingSource.DataSource = MyDataTable;
                    MySortOrder = SortOrder.Descending;
                    break;
                case SortOrder.Descending:
                    MyDataTable.DefaultView.Sort = Properties.Settings.Default.OderDataGridView; //SqlOriginOrder
                    MyDataTable = MyDataTable.DefaultView.ToTable();
                    MyBindingSource.DataSource = MyDataTable;
                    MySortOrder = SortOrder.None;
                    break;
            }
            base.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = MySortOrder; //mini arrow 
        }
    }
