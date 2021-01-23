	Private Sub grid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles grid.ColumnHeaderMouseClick
		Dim col = grid.Columns(e.ColumnIndex)
		Dim dir As System.ComponentModel.ListSortDirection
		Select Case col.HeaderCell.SortGlyphDirection
			Case SortOrder.None, SortOrder.Ascending
				dir = System.ComponentModel.ListSortDirection.Ascending
			Case Else
				dir = System.ComponentModel.ListSortDirection.Descending
		End Select
		grid.Sort(col, dir)
	End Sub
	Private Sub grid_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) Handles grid.SortCompare
		'This event occurs only when the DataSource property is not set and the VirtualMode property value is false.
		If e.Column.Name = "DateProperty" Then
			e.SortResult = Date.Compare(CType(e.CellValue1, Date), CType(e.CellValue2, Date))
			e.Handled = True
		End If
	End Sub
