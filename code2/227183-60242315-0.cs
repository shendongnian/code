    private void EvtDataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        CustomDataGridView MyDataGridView = sender as CustomDataGridView;
        BindingSource MyBindingSource = (BindingSource)MyDataGridView.DataSource;
        //DataTable MyDataTable = (DataTable)MyBindingSource.DataSource;
        //DataGridViewColumn column = MyDataGridView.Columns[e.ColumnIndex];
        switch (MyDataGridView.MySortOrder)
        {
                case SortOrder.None:
                        MyBindingSource.Sort = MyDataGridView.Columns[e.ColumnIndex].Name + "ASC";
                        MyDataGridView.MySortOrder = SortOrder.Ascending;           //save current state
                        break;
                case SortOrder.Ascending:
                        MyBindingSource.Sort = MyDataGridView.Columns[e.ColumnIndex].Name + "DESC";
                        MyDataGridView.MySortOrder = SortOrder.Descending;          //save current state
                        break;
                case SortOrder.Descending:
                        MyBindingSource.RemoveSort();
                        MyDataGridView.MySortOrder = SortOrder.None;                                //save current state
                        break;
        }
        MyDataGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = MyDataGridView.MySortOrder;           //the mini arrow
    }
