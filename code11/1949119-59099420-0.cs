    Protected Sub SetRowAdded(ByVal DataTable As DataTable)
            'Accept pending changes, as only Unchanged rows can be changed to Added or Modified
            DataTable.AcceptChanges()
    
            For Each row As DataRow In DataTable.Rows
                If Not row.RowState = DataRowState.Added Then row.SetAdded()
            Next
     End Sub
