    Private Sub CheckForDragDrop(sender As Object, e As MouseEventArgs)
      If e.Button = MouseButtons.Left Then
        Dim ht As DataGridView.HitTestInfo = Me.HitTest(e.X, e.Y)
        If (ht.Type = DataGridViewHitTestType.RowHeader OrElse ht.Type = DataGridViewHitTestType.Cell) AndAlso Me.Rows(ht.RowIndex).Selected Then
          _ColumnDragInProgress = True
          If Me.SelectedRows.Count > 1 Then
            Me.DoDragDrop(Me.SelectedRows, DragDropEffects.All)
          ElseIf Me.CurrentRow IsNot Nothing Then
            Me.DoDragDrop(Me.CurrentRow, DragDropEffects.All)
          End If
        End If
      End If
    End Sub
