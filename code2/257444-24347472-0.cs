    Private Sub data_ColumnDisplayIndexChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles data.ColumnDisplayIndexChanged
        
        Debug.Print(e.Column.DisplayIndex & vbTab & e.Column.Name)
        
    End Sub
