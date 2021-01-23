	// Restore the sort
	uiGrid.Sort(oldSortColumn, oldSortOrder);
	// Restore Selected rows
	foreach (DataGridViewRow row in uiGrid.SelectedRows)
	{
		if (selectedRows.Contains(row.Cells["SomeIndexColumn"].Value.ToString()))
		{
			row.Selected = true;
		}
	}
