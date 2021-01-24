    Private Sub dgv_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = vbNull Or dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub
