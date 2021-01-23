        private void MyDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            dirtyCellListenerEnabled = false;
            SORT_ORDER.ValueType = MyDataGridView.Columns[e.ColumnIndex].ValueType;
            foreach(DataGridViewRow r in MyDataGridView.Rows) {
                r.Cells[SORT_ORDER.Index].Value = r.Cells[e.ColumnIndex].Value;
            }
            switch(MyDataGridView.SortOrder) {
                case System.Windows.Forms.SortOrder.None:
                    MyDataGridView.Sort(SORT_ORDER, ListSortDirection.Ascending);
                    break;
                case System.Windows.Forms.SortOrder.Ascending:
                    MyDataGridView.Sort(SORT_ORDER, ListSortDirection.Descending);
                    break;
                case System.Windows.Forms.SortOrder.Descending:
                    MyDataGridView.Sort(SORT_ORDER, ListSortDirection.Ascending);
                    break;
            }
            dirtyCellListenerEnabled = true;
        }
