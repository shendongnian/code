    Private Sub dataAnts_ColumnDisplayIndexChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dataAnts.ColumnDisplayIndexChanged
        If bSortingColumns = False Then
            Debug.Print(e.Column.DisplayIndex & vbTab & e.Column.Name)
        End If
    End Sub
