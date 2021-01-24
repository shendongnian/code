    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
      If e.Button = Windows.Forms.MouseButtons.Right AndAlso ColDragInProgress Then
        ColDragInProgress = False
        Dim ht As DataGridView.HitTestInfo
        ht = Me.HitTest(e.X, e.Y)
        If ht.ColumnIndex>=0 AndAlso Not Me.Columns(ht.ColumnIndex).Selected Then  'On a Not selected Column so assume Drag Complete
          Dim MoveToColumn As Integer = ht.ColumnIndex
          PerformMovedColsToNewPosition(MoveToColumn, SelectedColumns)  'Your code to reorder cols as you want
        Else
          MyBase.OnMouseDown(e)
        End If
      Else
        MyBase.OnMouseUp(e) 'now call the base Up-function
      End If
    End Sub
