          private void myDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {
         DataGridViewColumn column = myDataGridView.Columns[e.ColumnIndex];
         _isSortAscending = (_sortColumn == null || _isSortAscending == false);
         string direction = _isSortAscending ? "ASC" : "DESC";
         myBindingSource.DataSource = _context.MyEntities.OrderBy(
            string.Format("it.{0} {1}", column.DataPropertyName, direction)).ToList();
         if (_sortColumn != null) _sortColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
         column.HeaderCell.SortGlyphDirection = _isSortAscending ? SortOrder.Ascending : SortOrder.Descending;
         _sortColumn = column;
      }
