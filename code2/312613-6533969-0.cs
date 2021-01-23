	// Store the sort details.
	ListSortDirection oldSortOrder;
	switch (uiGrid.SortOrder)
	{
		case SortOrder.Ascending:
			oldSortOrder = ListSortDirection.Ascending;
			break;
		case SortOrder.Descending:
			oldSortOrder = ListSortDirection.Descending;
			break;
		default:
			oldSortOrder = ListSortDirection.Ascending;
			break;
	}
	
	DataGridViewColumn oldSortColumn = uiGrid.SortedColumn;
	// Store the selected rows
	List<String> selectedRows = new List<String>();
	foreach (DataGridViewRow row in uiGrid.SelectedRows)
	{
		selectedRows.Add(row.Cells["SomeIndexColumn"].Value.ToString());
	}
