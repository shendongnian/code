    Private Sub FooBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FooBindingSource.CurrentItemChanged
         Dim thisDataRow As DataRow = DirectCast(DirectCast(sender, BindingSource).Current, DataRowView).Row
         If thisDataRow.RowState = DataRowState.Modified Then
             Me.FooTableAdapter.Update(thisDataRow)
         End If
    End Sub
