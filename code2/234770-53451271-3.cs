		private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			// Record what the new first sorting column is
			this._sorters.BringColumnToFrontOfSortingOrder(dgv.SortedColumn.Name, dgv.SortOrder == SortOrder.Ascending);
			// Change the sort order of my DataView; assigning a new value to Sort causes immediate re-ordering.
			// Because my DataGridView is bound to my data grid view as its DataSource, 
			// changes to the DataView immediately show on the DataGridView.
			this._dvw.Sort = this._sorters.ToString();
		}
