    Private Sub PerformDragEnter(sender As Object, e As DragEventArgs)
      If e.Data.GetDataPresent(GetType(DataGridViewRow)) OrElse e.Data.GetDataPresent(GetType(DataGridViewSelectedRowCollection)) Then
        e.Effect = DragDropEffects.Copy
      End If
    End Sub
    Private Sub PerformDragDrop(sender As Object, e As DragEventArgs)
      Dim dscreen As Point = New Point(e.X, e.Y)
      Dim dclient As Point = Me.PointToClient(dscreen)
      Dim HitTest As HitTestInfo = Me.HitTest(dclient.X, dclient.Y)
      'If dropped onto an Existing Row, use that Row as Sender - otherwise Sender=This DGV.
      If HitTest.RowIndex >= 0 Then _Dropped_RowHit = Me.Rows(HitTest.RowIndex) Else _Dropped_RowHit = Nothing
      Dim DroppedRows As New List(Of DataGridViewRow)
      If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
        DroppedRows.Add(e.Data.GetData(GetType(DataGridViewRow)))
      ElseIf e.Data.GetDataPresent(GetType(DataGridViewSelectedRowCollection)) Then
        Dim Rows As DataGridViewSelectedRowCollection = e.Data.GetData(GetType(DataGridViewSelectedRowCollection))
        For Each rw As DataGridViewRow In Rows
          DroppedRows.Add(rw)
        Next
      Else
        DroppedRows = Nothing
        Exit Sub
      End If
      If DroppedRows(0).DataGridView Is Me Then Exit Sub
      e.Data.SetData(DroppedRows)
      _DraggedFrom_Name = DroppedRows(0).DataGridView.Name
      'Drop occurred, add your code to handle it here
    End Sub
